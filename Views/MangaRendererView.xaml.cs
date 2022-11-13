using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MangaReaderView
    {
        private readonly MangaReaderViewModel _mangaReaderViewModel;
        
        public MangaReaderView(MangaReaderViewModel mangaReaderViewModel)
        {
            _mangaReaderViewModel = mangaReaderViewModel;
            DataContext = mangaReaderViewModel;
            InitializeComponent();
        }

        private void LeftButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mangaReaderViewModel.GoToNextPage();
        }
        
        private void RightButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mangaReaderViewModel.GoToPreviousPage();
        }
    }
}