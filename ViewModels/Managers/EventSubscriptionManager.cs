using Models.CustomEventArgs;
using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Managers;
public class EventSubscriptionManager : IEventSubscriptionManager
{
    private readonly Dictionary<Type, HashSet<object>> _subscriptions = new();

    public void Subscribe<T>(object subscriber, Func<object, T, Task> handler) where T : EventArgs
    {
        lock (_subscriptions)
        {
            SubscribeInternal(subscriber, handler);
        }
    }

    public void Unsubscribe<T>(object subscriber, Func<object, T, Task> handler) where T : EventArgs
    {
        lock (_subscriptions)
        {
            UnsubscribeInternal(subscriber, handler);
        }
    }

    public async Task Publish<T>(object sender, T eventArgs) where T : EventArgs
    {
        if (eventArgs is null) return;

        HashSet<object> subscriptions;

        lock (_subscriptions)
        {
            if (!_subscriptions.TryGetValue(eventArgs?.GetType(), out var subscriptionsObj) || subscriptionsObj?.Any() == false)
            {
                return;
            }

            subscriptions = subscriptionsObj;
        }

        await PublishInternal(subscriptions, sender, eventArgs);
    }

    private void SubscribeInternal<T>(object subscriber, Func<object, T, Task> handler) where T : EventArgs
    {
        var sub = EventSubscription<T>.Create(subscriber, handler);

        if (!_subscriptions.TryGetValue(typeof(T), out var subscriptions) || subscriptions is null)
        {
            subscriptions = new HashSet<object>();
            _subscriptions.Add(typeof(T), subscriptions);
        }

        subscriptions.Add(sub);
    }

    private void UnsubscribeInternal<T>(object subscriber, Func<object, T, Task> handler) where T : EventArgs
    {
        if (!_subscriptions.TryGetValue(typeof(T), out var subscriptions) || subscriptions?.Any() == false)
        {
            return;
        }

        var sub = EventSubscription<T>.Create(subscriber, handler);
        subscriptions.Remove(sub);
    }

    private static async Task PublishInternal<T>(HashSet<object> subscriptions, object sender, T args) where T : EventArgs
    {
        var tasks = subscriptions.Select(x =>
            x is EventSubscription<T> subscription
                ? subscription.Handler(sender, args)
                : Task.CompletedTask).ToList();

        while (tasks.Any())
        {
            var result = await Task.WhenAny(tasks);
            tasks.Remove(result);
        }
    }
}
