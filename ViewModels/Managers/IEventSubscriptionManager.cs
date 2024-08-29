using System;
using System.Threading.Tasks;

namespace ViewModels.Managers;
public interface IEventSubscriptionManager
{
    Task Publish<T>(object sender, T eventArgs) where T : EventArgs;

    Task Publish<T>(object sender, object parameters, T eventArgs) where T : EventArgs;

    void Subscribe<T>(object subscriber, Func<object, object, T, Task> handler) where T : EventArgs;

    void Unsubscribe<T>(object subscriber, Func<object, object, T, Task> handler) where T : EventArgs;
}