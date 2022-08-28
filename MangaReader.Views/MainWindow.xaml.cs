using System;
using System.Windows;

namespace MangaReader.Views;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public BrowserView BrowserView => BrowserViewPanel;

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        Application.Current.Shutdown();
    }
}