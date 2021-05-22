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
            var path = @"C:\Users\joshr\Desktop\TestData";
            var mangaInfo = new MangaInfo(path, Directory.GetFiles(path));
            var mangaReaderViewModel = new MangaReaderViewModel(mangaInfo);
            var mangaReaderView = new MangaReaderView(mangaReaderViewModel) {Title = "MangaReader"};

            mangaReaderView.Show();
        }
    }
}