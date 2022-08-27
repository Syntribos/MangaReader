using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MangaReader.Models;
using MangaReader.ViewModels;

namespace MangaReader.Views
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