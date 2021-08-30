using System;
using System.IO;
using System.Windows;
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
            var mangaInfo = new MangaChapter(path, Directory.GetFiles(path));
            var mangaReaderViewModel = new MangaReaderViewModel(mangaInfo);
            var mangaReaderView = new MangaReaderView(mangaReaderViewModel) {Title = "MangaReader"};

            mangaReaderView.Show();
        }
    }
}