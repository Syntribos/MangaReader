using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.CustomEventArgs;

namespace Messaging;

public class EventSubscriptionManager : IEventSubscriptionManager
{
    private readonly Dictionary<Type, HashSet<object>> _subscriptions = new();

    public void Subscribe<T>(object subscriber, Func<object, T, Task> handler) where T : EventArgs
    {
        var sub = EventSubscription<T>.Create(subscriber, handler);

        lock (_subscriptions)
        {
            SubscribeInternal(sub);
        }
    }

    public void Subscribe<T>(object subscriber, Func<object, object?, T, Task> handler) where T : EventArgs
    {
        var sub = EventSubscription<T>.Create(subscriber, handler);

        lock (_subscriptions)
        {
            SubscribeInternal(sub);
        }
    }

    public void Unsubscribe<T>(object subscriber, Func<object, T, Task> handler) where T : EventArgs
    {
        var sub = EventSubscription<T>.Create(subscriber, handler);

        lock (_subscriptions)
        {
            UnsubscribeInternal(sub);
        }
    }

    public void Unsubscribe<T>(object subscriber, Func<object, object?, T, Task> handler) where T : EventArgs
    {
        var sub = EventSubscription<T>.Create(subscriber, handler);

        lock (_subscriptions)
        {
            UnsubscribeInternal(sub);
        }
    }

    public async Task Publish<T>(object sender, T eventArgs) where T : EventArgs => await Publish<T>(sender, eventArgs, null);

    public async Task Publish<T>(object sender, T eventArgs, object? parameters) where T : EventArgs
    {
        if (eventArgs is null) return;

        HashSet<object> subscriptions;

        lock (_subscriptions)
        {
            if (!_subscriptions.TryGetValue(eventArgs.GetType(), out var subscriptionsObj) || subscriptionsObj.Count == 0)
            {
                return;
            }

            subscriptions = subscriptionsObj;
        }

        await PublishInternal(subscriptions, sender, eventArgs, parameters);
    }

    private void SubscribeInternal<T>(IEventSubscription<T> sub) where T : EventArgs
    {
        if (!_subscriptions.TryGetValue(typeof(T), out var subscriptions) || subscriptions is null)
        {
            subscriptions = new HashSet<object>();
            _subscriptions.Add(typeof(T), subscriptions);
        }

        subscriptions.Add(sub);
    }

    private void UnsubscribeInternal<T>(IEventSubscription<T> sub) where T : EventArgs
    {
        if (_subscriptions.TryGetValue(typeof(T), out var subscriptions) && (subscriptions.Count != 0))
        {
            subscriptions.Remove(sub);
        }
    }

    private static async Task PublishInternal<T>(HashSet<object> subscriptions, object sender, T args, object? parameters) where T : EventArgs
    {
        var tasks = subscriptions.Select(x =>
            x is EventSubscription<T> subscription
                ? subscription.Invoke(sender, parameters, args)
                : Task.CompletedTask).ToList();

        while (tasks.Count != 0)
        {
            var result = await Task.WhenAny(tasks);
            tasks.Remove(result);
        }
    }
}
