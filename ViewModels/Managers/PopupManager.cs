using Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ViewModels.Managers;
public class PopupManager : EventSubscriber
{
    private readonly IUserInterfaceUpdater _userInterfaceUpdater;

    public PopupManager(IEventSubscriptionManager subscriptionManager, IUserInterfaceUpdater userInterfaceUpdater)
        : base(subscriptionManager)
    {
        Contract.RequireNotNull((subscriptionManager, nameof(subscriptionManager)),
                                (userInterfaceUpdater, nameof(userInterfaceUpdater)));

        SubscriptionManager = subscriptionManager;
        _userInterfaceUpdater = userInterfaceUpdater;
    }

    protected override IEventSubscriptionManager SubscriptionManager { get; init; }

    protected override void Subscribe()
    {
        SubscriptionManager.Subscribe<ShowPopupEventArgs>(this, ShowPopup);
    }

    protected override void Unsubscribe()
    {
        SubscriptionManager.Unsubscribe<ShowPopupEventArgs>(this, ShowPopup);
    }

    private Task ShowPopup(object sender, object parameters, ShowPopupEventArgs args)
    {
        return Task.CompletedTask;
    }
}
