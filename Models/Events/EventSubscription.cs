using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Models.CustomEventArgs;
public interface IEventSubscription<T> where T : EventArgs
{
    public object Subscriber { get; }

    public Task Invoke(object sender, object parameters, T args);
}

public class EventSubscription<T> : IEventSubscription<T> where T : EventArgs
{
    private readonly Func<object, object, T, Task> _parameteredHandler;
    private readonly Func<object, T, Task> _paramlessHandler;

    private EventSubscription(object subscriber, Func<object, object, T, Task> handler)
    {
        Contract.RequireNotNull((subscriber, nameof(subscriber)),
                                (handler, nameof(handler)));

        Subscriber = subscriber;
        _parameteredHandler = handler;
        _paramlessHandler = null;
    }

    private EventSubscription(object subscriber, Func<object, T, Task> handler)
    {
        Contract.RequireNotNull((subscriber, nameof(subscriber)),
                    (handler, nameof(handler)));

        Subscriber = subscriber;
        _parameteredHandler = null;
        _paramlessHandler = handler;
    }

    public object Subscriber { get; }

    public Task Invoke(object sender, object parameters, T args)
    {
        return _parameteredHandler?.Invoke(sender, parameters, args)
            ?? _paramlessHandler?.Invoke(sender, args);
    }

    public static IEventSubscription<T> Create(object subscriber, Func<object, object, T, Task> handler)
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
            return new EventSubscription<T>(subscriber, handler);
        }
        catch (ArgumentException ex)
        {
            throw new SubscriptionException(ex.Message);
        }
    }
}
