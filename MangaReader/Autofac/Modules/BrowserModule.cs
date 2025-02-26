using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels;

using Autofac;
using Views;

namespace MangaReader.Autofac.Modules;

public class BrowserModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();
        builder.RegisterType<MainWindow>().SingleInstance();
        builder.RegisterType<BrowserViewModel>().SingleInstance();
        builder.RegisterType<CategoryBrowserViewModel>()
            .As<ICategoryBrowserViewModel>().As<IInitialBrowserView>()
            .SingleInstance();
    }
}
