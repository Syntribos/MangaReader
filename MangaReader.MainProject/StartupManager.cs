using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MangaReader.Data;
using MangaReader.Data.Implementations;
using MangaReader.DataManager;
using MangaReader.DataManager.Implementations;
using MangaReader.Models;
using MangaReader.Utilities;
using MangaReader.ViewModels;
using MangaReader.ViewModels.Commands;

namespace MangaReader.MainProject;

public class StartupManager
{
    public IContainer BuildAppContainer(string databasePath)
    {
        var builder = new ContainerBuilder();

        builder.Register<IConnectionStringProvider>(x => new ConnectionStringProvider(databasePath))
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
        builder.RegisterType<CategoryBrowserViewModel>().As<IBrowserView>().SingleInstance();
        builder.RegisterType<Categories>().SingleInstance();
        
        builder.RegisterType<BrowserViewModel>().SingleInstance();

        return builder.Build();
    }
}

/*
            var path = @"C:\Users\Jess\Desktop\Images\Avatars";
            
            var dbPath = @"C:\Databases\manga.db";
            var imagePaths = Directory.GetFiles(path);
            var mangaSeriesPreview =
                new SeriesPreview(Guid.NewGuid(), "A Cool Series Name", imagePaths.First(), imagePaths.Length, 0);
            var seriesRepository = new SeriesRepository(dbPath);
            var databaseQuerier = new DatabaseQuerier(new Manager(new SeriesManager(seriesRepository)));
            var showSeriesCommand = new ShowSeriesCommand();
            var categoryViewModel = new CategoryBrowserViewModel(databaseQuerier, new UserInterfaceUpdater(TaskScheduler.FromCurrentSynchronizationContext()), new Categories(), showSeriesCommand);
            categoryViewModel.DEBUGSetMangaList(new List<ISeriesPreview> { mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, });
            var browserViewModel = new BrowserViewModel(categoryViewModel, showSeriesCommand, databaseQuerier);

            return browserViewModel;
*/