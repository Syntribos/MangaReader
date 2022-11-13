using System;
using System.Windows;
using MangaReader.ViewModels;

namespace MangaReader.Views;

public partial class MainWindow
{
    public MainWindow(IMainWindowViewModel mainWindowViewModel, BrowserViewModel browserViewModel)
    {
        DataContext = mainWindowViewModel;
        InitializeComponent();

        BrowserView.DataContext = browserViewModel;
    }
    
    public BrowserView BrowserView => BrowserViewPanel;

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        Application.Current.Shutdown();
    }
}