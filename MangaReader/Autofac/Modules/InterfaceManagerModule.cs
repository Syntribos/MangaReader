using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ViewModels;
using ViewModels.Managers;
using Views;

namespace MangaReader.Autofac.Modules;

public class InterfaceManagerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ViewStateManager>().As<IViewStateManager>().SingleInstance();
        builder.Register<IUserInterfaceUpdater>(x => new UserInterfaceUpdater(TaskScheduler.FromCurrentSynchronizationContext()))
            .As<IUserInterfaceUpdater>().SingleInstance();
    }
}
