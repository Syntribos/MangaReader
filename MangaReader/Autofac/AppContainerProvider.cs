using System.Threading.Tasks;
using Autofac;
using Data;
using Data.Implementations;
using DataManager;
using DataManager.Implementations;
using MangaReader.Autofac.AutofacModules;
using MangaReader.Autofac.Modules;
using Models;
using Utilities;
using ViewModels;
using ViewModels.Commands;
using ViewModels.Commands.CommandImplementations;
using ViewModels.Managers;
using ViewModels.Popups;
using Views;
using Views.Popups;

namespace MangaReader.Autofac;

public class AppContainerProvider
{
    public static IContainer BuildAppContainer()
    {
        var builder = SharedContainerProvider.CreateSharedBuilder();

        RegisterUiModules(builder);

        return builder.Build();
    }

    private static void RegisterUiModules(ContainerBuilder builder)
    {
        // UI Modules
        builder.RegisterModule<InterfaceManagerModule>();
        builder.RegisterModule<BrowserModule>();
        builder.RegisterModule<PopupModule>();
        builder.RegisterModule<UiCommandModule>();
    }
}