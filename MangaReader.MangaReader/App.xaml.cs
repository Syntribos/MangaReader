using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using MangaReader.Models;
using MangaReader.Views;
using MangaReader.ViewModels;

namespace MangaReader.MangaReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create the startup window
            var path = @"C:\Users\Josh\Desktop\Images";
            var mangaInfo = new MangaInfo(path, Directory.GetFiles(path));
            var mrvw = new MangaReaderViewModel(mangaInfo);
            var wnd = new MangaReaderView(mrvw) {Title = "MangaReader"};
            // Do stuff here, e.g. to the window
            // Show the window
            wnd.Show();
        }
    }
}