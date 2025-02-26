using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels.Popups;

using Autofac;
using Views.Popups;

namespace MangaReader.Autofac.Modules;

public class PopupModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PopupBuilder>().As<IPopupBuilder>().SingleInstance();
        builder.RegisterType<PopupManager>().As<IPopupManager>().SingleInstance();
    }
}
