using System.Windows;
using System.Windows.Controls;
using MangaReader.ViewModels;

namespace MangaReader.Views
{
    public partial class CategoryBrowserView : Window
    {
        private CategoryBrowserViewModel _categoryBrowserViewModel;

        public CategoryBrowserView(CategoryBrowserViewModel categoryBrowserViewModel)
        {
            _categoryBrowserViewModel = categoryBrowserViewModel;
            DataContext = categoryBrowserViewModel;
            InitializeComponent();
        }
    }
}