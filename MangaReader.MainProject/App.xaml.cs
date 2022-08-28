using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

using MangaReader.Data;
using MangaReader.Models;
using MangaReader.Views;
using MangaReader.ViewModels;
using MangaReader.ViewModels.Commands;

namespace MangaReader.MainProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private MainWindow _mainWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the startup window
            var path = @"C:\Users\Jess\Desktop\Images\Avatars";
            var dbPath = @"C:\Databases\manga.db";
            var imagePaths = Directory.GetFiles(path);
            var mangaSeriesPreview =
                new SeriesPreview(Guid.NewGuid(), "A Cool Series Name", imagePaths.First(), imagePaths.Length, 0);
            var showSeriesCommand = new ShowSeriesCommand();
            var categoryViewModel = new CategoryBrowserViewModel(new SeriesRepository(dbPath), new Categories(), showSeriesCommand);

            // var mangaReaderView = CreateMangaReaderView(path, imagePaths);
            var seriesRepository = new SeriesRepository(dbPath);

            categoryViewModel.DEBUGSetMangaList(new List<ISeriesPreview> { mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, mangaSeriesPreview, });

            var mainWindowViewModel = new MainWindowViewModel();
            var browserViewModel = new BrowserViewModel(categoryViewModel, showSeriesCommand, seriesRepository);
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
}