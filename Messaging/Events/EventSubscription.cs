using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Messaging.Events.Exceptions;
using Utilities;

namespace Models.CustomEventArgs;
public interface IEventSubscription<T> where T : EventArgs
{
    public object Subscriber { get; }

    public Task Invoke(object sender, object parameters, T args);
}

public class EventSubscription<T> : IEventSubscription<T> where T : EventArgs
{
    private readonly Func<object, object?, T, Task> _handler;

    private EventSubscription(object subscriber, Func<object, object?, T, Task> handler)
    {
        Contract.RequireNotNull((subscriber, nameof(subscriber)),
                                (handler, nameof(handler)));

        Subscriber = subscriber;
        _handler = handler;
    }

    public object Subscriber { get; }

    public Task Invoke(object sender, object? parameters, T args)
    {
        return _handler.Invoke(sender, parameters, args);
    }

    public static IEventSubscription<T> Create(object subscriber, Func<object, object?, T, Task> handler)
    {
        try
        {
            return new EventSubscription<T>(subscriber, handler);
        }
        catch (ArgumentException ex)
        {
            throw new SubscriptionException(ex.Message);
        }
    }

    public static IEventSubscription<T> Create(object subscriber, Func<object, T, Task> handler)
    {
        try
        {
            return new EventSubscription<T>(subscriber, ToParametered(handler));
        }
        catch (ArgumentException ex)
        {
            throw new SubscriptionException(ex.Message);
        }
    }

    private static Func<object, object?, T, Task> ToParametered(Func<object, T, Task> handler)
        => new Func<object, object?, T, Task>((object t, object? _, T e) => handler(t, e));
}
