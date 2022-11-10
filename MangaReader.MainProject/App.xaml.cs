using System.Linq;
using System.Windows;

using MangaReader.Models;
using MangaReader.Views;
using MangaReader.ViewModels;

using Autofac;
using MangaReader.Scrapers;

namespace MangaReader.MainProject;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private readonly AppContainerProvider _startupManager;
    private MainWindow _mainWindow;

    public App()
    {
        _startupManager = new AppContainerProvider(@"C:\Databases\manga.db");
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var container = _startupManager.BuildAppContainer();
        var browserViewModel = container.Resolve<BrowserViewModel>();
        var mainWindowViewModel = new MainWindowViewModel();

        var scraperProvider = container.Resolve<IScraperProvider>();

        var mangaUrl =
            @"https://mangadex.org/title/ffe69cc2-3f9e-4eab-a7f7-c963cea9ec25/lonely-attack-on-a-different-world";
        var mdScraper = scraperProvider.GetByUrl(mangaUrl);
        mdScraper.AddManga(mangaUrl);
        

        _mainWindow = new MainWindow { DataContext = mainWindowViewModel };
        Current.MainWindow = _mainWindow;
        _mainWindow.BrowserView.DataContext = browserViewModel;
        _mainWindow.Show();
    }
    private static MangaReaderView CreateMangaReaderView(string path, string[] imagePaths)
    {
        var mangaInfo = new MangaChapterPreview("A Cool Chapter Name", 1, imagePaths.Length, path, imagePaths.First());
        var mangaReaderViewModel = new MangaReaderViewModel(mangaInfo.ToChapter(imagePaths));
        return new MangaReaderView(mangaReaderViewModel) {Title = "MangaReader"};
    }
}