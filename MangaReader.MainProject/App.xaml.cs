using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using MangaReader.Data;
using MangaReader.Data.Implementations;
using MangaReader.DataManager;
using MangaReader.DataManager.Implementations;
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
        private readonly StartupManager _startupManager;
        private MainWindow _mainWindow;

        public App()
        {
            _startupManager = new StartupManager();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var container = _startupManager.BuildAppContainer(@"C:\Databases\manga.db");
            var browserViewModel = container.Resolve<BrowserViewModel>();
            var mainWindowViewModel = new MainWindowViewModel();

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