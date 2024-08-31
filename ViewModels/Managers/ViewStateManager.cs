using Models;
using Models.CustomEventArgs;
using Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ViewModels.Popups;

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
        SubscriptionManager.Subscribe<ShowChapterEventArgs>(this, ShowChapterEvent);
    }

    protected override void Unsubscribe()
    {
        SubscriptionManager.Unsubscribe<ShowChapterEventArgs>(this, ShowChapterEvent);
    }

    private async Task ShowChapterEvent(object sender, ShowChapterEventArgs e)
    {
        var popupInfo = PopupInfo.FromEventArgs(e);

        await SubscriptionManager.Publish(this, new ShowPopupEventArgs(Popup.Chapter), popupInfo);
    }
}
