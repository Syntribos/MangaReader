using Models.CustomEventArgs;
using Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ViewModels.Managers;
public class ViewStateManager : EventSubscriber, IViewStateManager
{
    public ViewStateManager(IEventSubscriptionManager subscriptionManager)
        : base(subscriptionManager)
    {
        Contract.RequireNotNull((subscriptionManager, nameof(subscriptionManager)));
        SubscriptionManager = subscriptionManager;
    }

    protected override IEventSubscriptionManager SubscriptionManager { get; init; }

    public event ViewStateChangeRequestHandler ViewStateChangeRequest;

    protected override void Subscribe()
    {
        SubscriptionManager.Subscribe<ShowChapterEventArgs>(this, ShowSeriesEvent);
    }

    protected override void Unsubscribe()
    {
        SubscriptionManager.Unsubscribe<ShowChapterEventArgs>(this, ShowSeriesEvent);
    }

    private Task ShowSeriesEvent(object sender, ShowChapterEventArgs e)
    {
        return Task.CompletedTask;
    }
}
