using System.Windows;
using MangaReader.ViewModels;

namespace MangaReader.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public BrowserView BrowserView => BrowserViewPanel;
}