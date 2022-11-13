using System.Windows;

using Views;
using Scrapers;

using Autofac;


namespace MangaReader;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private const string DB_PATH = @"C:\Databases\manga.db";
    private const string TEST_MANGA_URL =
        @"https://mangadex.org/title/ffe69cc2-3f9e-4eab-a7f7-c963cea9ec25/lonely-attack-on-a-different-world";

    private readonly AppContainerProvider _appContainerProvider;

    private MainWindow _mainWindow;

    public App()
    {
        _appContainerProvider = new AppContainerProvider(DB_PATH);
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var container = _appContainerProvider.BuildAppContainer();

        ScraperTest(container);

        _mainWindow = container.Resolve<MainWindow>();
        Current.MainWindow = _mainWindow;
        _mainWindow.Show();
    }

    private static void ScraperTest(IComponentContext container)
    {
        var scraperProvider = container.Resolve<IScraperProvider>();
        var mdScraper = scraperProvider.GetByUrl(TEST_MANGA_URL);
        mdScraper.AddManga(TEST_MANGA_URL);
    }
}