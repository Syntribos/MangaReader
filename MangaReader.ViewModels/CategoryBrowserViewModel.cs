using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MangaReader.Data.Interfaces;
using MangaReader.Models;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels
{
    public class CategoryBrowserViewModel : BrowserViewBase
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly Categories _categories;

        private IEnumerable<ISeriesPreview> _seriesPreviews;

        public CategoryBrowserViewModel(ISeriesRepository seriesRepository, Categories categories, ICommand showSeriesCommand)
        {
            _seriesRepository = seriesRepository;
            _categories = categories;
            ShowSeriesCommand = showSeriesCommand;
        }
        
        public ICommand ShowSeriesCommand { get; }

        public double SeriesPerRow => 7;

        public double RowsPerPage => 2;
        
        public IEnumerable<ISeriesPreview> SeriesList {

            get => _seriesPreviews;

            private set
            {
                if (value.Equals(_seriesPreviews))
                {
                    return;
                }

                _seriesPreviews = value;
                OnPropertyChanged();
            }
        }

        public void DEBUGSetMangaList(IEnumerable<ISeriesPreview> seriesList)
        {
            SeriesList = seriesList;
        }

        public void ChangeCategoryByName(string categoryName)
        {
            ChangeCategoryByIndex(_categories.GetCategoryIndexByName(categoryName));
        }

        public void ChangeCategoryByIndex(int categoryIndex)
        {
            SeriesList = _seriesRepository.GetMangaPreviewsForCategory(categoryIndex);
            OnPropertyChanged(nameof(SeriesList));
        }
    }
}