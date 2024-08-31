using Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;
using ViewModels;
using ViewModels.Managers;
using ViewModels.Popups;

namespace Views.Popups;
public class PopupManager : EventSubscriber, IPopupManager
{
    private readonly IUserInterfaceUpdater _userInterfaceUpdater;
    private readonly IPopupBuilder _popupBuilder;

    public PopupManager(IEventSubscriptionManager subscriptionManager, IUserInterfaceUpdater userInterfaceUpdater, IPopupBuilder popupBuilder)
        : base(subscriptionManager)
    {
        Contract.RequireNotNull((subscriptionManager, nameof(subscriptionManager)),
                                (userInterfaceUpdater, nameof(userInterfaceUpdater)),
                                (popupBuilder, nameof(popupBuilder)));

        SubscriptionManager = subscriptionManager;
        _userInterfaceUpdater = userInterfaceUpdater;
        _popupBuilder = popupBuilder;
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

    private async Task ShowPopup(object sender, object parameters, ShowPopupEventArgs args)
    {
        var popup = _popupBuilder.Build(parameters);

        if (popup is null)
        {
            throw new InvalidOperationException($"Couldn't build popup from {sender.GetType()} using parameters {parameters?.ToString() ?? "null"}.");
        }

        await _userInterfaceUpdater.RunOnUi(() =>
            {
                var popupHost = new PopupHostWindow(popup);
                popupHost.Show();
            },
            CancellationToken.None,
            (ex) => Console.WriteLine(ex.Message));
    }
}
