using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using MangaReader.Data;
using MangaReader.Models;
using MangaReader.Views;
using MangaReader.ViewModels;

namespace MangaReader.MainProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the startup window
            var path = @"C:\Users\Jess\Desktop\Images\Avatars";
            var dbPath = @"C:\Databases\manga.db";
            var mangaInfo = new MangaChapter(path, Directory.GetFiles(path));
            var mangaSeries = new Series(new HashSet<IChapter> { mangaInfo }, "Stuff", @"C:\Users\Jess\Desktop\Images\Avatars\Hair.png");
            var categoryViewModel = new CategoryBrowserViewModel(new SeriesRepository(new MangaFactory(), dbPath), new Categories());
            var categoryView = new CategoryBrowserView(categoryViewModel);
            var mangaReaderViewModel = new MangaReaderViewModel(mangaInfo);
            var mangaReaderView = new MangaReaderView(mangaReaderViewModel) {Title = "MangaReader"};

            categoryViewModel.DEBUGSetMangaList(new List<ISeries> { mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, mangaSeries, });

            categoryView.Show();
        }
    }
}