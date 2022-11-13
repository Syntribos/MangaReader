using System.Threading.Tasks;
using Autofac;
using Data;
using Data.Implementations;
using DataManager;
using DataManager.Implementations;
using Models;
using Utilities;
using ViewModels;
using ViewModels.Commands;
using ViewModels.Commands.CommandImplementations;
using Views;

namespace MangaReader;

public class AppContainerProvider
{
    private readonly string _databasePath;

    public AppContainerProvider(string databasePath)
    {
        _databasePath = databasePath;
    }

    public IContainer BuildAppContainer()
    {
        var builder = new ContainerBuilder();

        builder.Register<IConnectionStringProvider>(x => new ConnectionStringProvider(_databasePath))
            .As<IConnectionStringProvider>().SingleInstance();
        builder.Register<IUserInterfaceUpdater>(x => new UserInterfaceUpdater(TaskScheduler.FromCurrentSynchronizationContext()))
            .As<IUserInterfaceUpdater>().SingleInstance();

        builder.RegisterType<ChapterRepository>().As<IChapterRepository>().SingleInstance();
        builder.RegisterType<SeriesRepository>().As<ISeriesRepository>().SingleInstance();
        builder.RegisterType<SettingsRepository>().As<ISettingsRepository>().SingleInstance();

        builder.RegisterType<Manager>().As<IManager>().SingleInstance();
        builder.RegisterType<DatabaseQuerier>().As<IDatabaseQuerier>().SingleInstance();
        builder.RegisterType<SeriesManager>().As<ISeriesManager>().SingleInstance();
        builder.RegisterType<SettingsManager>().As<ISettingsManager>().SingleInstance();

        builder.RegisterType<ShowSeriesCommand>().As<IShowSeriesCommand>().SingleInstance();
        builder.RegisterType<CategoryBrowserViewModel>()
            .As<ICategoryBrowserViewModel>().As<IInitialBrowserView>()
            .SingleInstance();
        builder.RegisterType<Categories>().SingleInstance();
        
        builder.RegisterType<BrowserViewModel>().SingleInstance();
        builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();
        builder.RegisterType<MainWindow>().SingleInstance();

        RegisterModules(builder);

        return builder.Build();
    }

    private static void RegisterModules(ContainerBuilder builder)
    {
        builder.RegisterModule<ScraperModule>();
    }
}