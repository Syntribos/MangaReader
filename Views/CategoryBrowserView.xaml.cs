using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

using Models;
using ViewModels;

namespace Views
{
    public partial class CategoryBrowserView : UserControl
    {
        public CategoryBrowserView()
        {
            InitializeComponent();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SeriesTileListBox.SelectedItem is ISeriesPreview seriesPreview)
            {
                var series = seriesPreview.ToSeries(new HashSet<IChapterPreview>());
            }
        }
    }
}