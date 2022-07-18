using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MangaReader.Data.Interfaces;
using MangaReader.Models;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels
{
    public class CategoryBrowserViewModel : INotifyPropertyChanged
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly Categories _categories;

        private IEnumerable<ISeries> _seriesList;

        public CategoryBrowserViewModel(ISeriesRepository seriesRepository, Categories categories)
        {
            _seriesRepository = seriesRepository;
            _categories = categories;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double SeriesPerRow => 7;

        public double RowsPerPage => 2;
        
        public IEnumerable<ISeries> SeriesList {

            get => _seriesList;

            private set
            {
                if (value.Equals(_seriesList))
                {
                    return;
                }

                _seriesList = value;
                OnPropertyChanged();
            }
        }

        public void DEBUGSetMangaList(IEnumerable<ISeries> seriesList)
        {
            SeriesList = seriesList;
        }

        public void ChangeCategoryByName(string categoryName)
        {
            ChangeCategoryByIndex(_categories.GetCategoryIndexByName(categoryName));
        }

        public void ChangeCategoryByIndex(int categoryIndex)
        {
            SeriesList = _seriesRepository.GetMangaForCategory(categoryIndex);
            OnPropertyChanged(nameof(SeriesList));
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}