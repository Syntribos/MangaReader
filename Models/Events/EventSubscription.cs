using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Models.CustomEventArgs;
public class EventSubscription<T> where T : EventArgs
{
    private EventSubscription(object subscriber, Func<object, T, Task> handler)
    {
        Contract.RequireNotNull((subscriber, nameof(subscriber)),
                                (handler,    nameof(handler)));

        Subscriber = subscriber;
        Handler = handler;
    }

    public object Subscriber { get; }

    public Func<object, T, Task> Handler { get; }

    public static EventSubscription<T> Create(object subscriber, Func<object, T, Task> handler)
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
