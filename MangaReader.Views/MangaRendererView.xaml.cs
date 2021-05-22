using MangaReader.ViewModels;

namespace MangaReader.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MangaReaderView
    {
        public MangaReaderView(MangaReaderViewModel mangaReaderViewModel)
        {
            DataContext = mangaReaderViewModel;
            InitializeComponent();
        }
    }
}