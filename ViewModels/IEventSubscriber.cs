using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Managers;

namespace ViewModels;
public abstract class EventSubscriber : IDisposable
{
    private bool _disposed;

    public EventSubscriber(IEventSubscriptionManager eventSubscriptionManager)
    {
        _disposed = false;
        SubscriptionManager = eventSubscriptionManager;
        Subscribe();
    }

    protected abstract IEventSubscriptionManager SubscriptionManager { get; init; }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        Unsubscribe();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    protected abstract void Subscribe();

    protected abstract void Unsubscribe();
}
