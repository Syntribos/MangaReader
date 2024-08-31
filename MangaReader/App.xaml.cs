using System.Windows;

using Views;

using Autofac;
using Scrapers;
using ViewModels;
using ViewModels.Commands.CommandImplementations;
using Models;
using System.IO;
using System;
using ViewModels.Commands;
using ViewModels.Managers;
using System.Threading.Tasks;
using Models.CustomEventArgs;
using MangaReader.Autofac;

namespace MangaReader;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private const string DB_PATH = @"C:\Databases\manga.db";
    private const string TEST_MANGA_URL =
        @"https://mangadex.org/title/ffe69cc2-3f9e-4eab-a7f7-c963cea9ec25/lonely-attack-on-a-different-world";

    private readonly AppContainerProvider _appContainerProvider = new(DB_PATH);
    private readonly LifetimeScope _lifetimeScope = new LifetimeScope();

    private MainWindow _mainWindow;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var container = _appContainerProvider.BuildAppContainer();
        _lifetimeScope.BuildLifetime(container);

        _mainWindow = container.Resolve<MainWindow>();
        Current.MainWindow = _mainWindow;
        _mainWindow.Show();

        var path = @"C:\Users\Jess\Desktop\Important\Images\Avatars";
        var imagePaths = Directory.GetFiles(path);
        var mc = new MangaChapter("Chapter Gay", 17, path, imagePaths);

        var eventSender = container.Resolve<IEventSubscriptionManager>();
        Task.Factory.StartNew(() => { eventSender.Publish(this, new ShowChapterEventArgs(mc)); }).GetAwaiter().GetResult();
    }

    private static void ScraperTest(IComponentContext container)
    {
        var scraperProvider = container.Resolve<IScraperProvider>();
        var mdScraper = scraperProvider.GetByUrl(TEST_MANGA_URL);
        mdScraper.AddManga(TEST_MANGA_URL);
    }
}