using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Input;

using DataManager;
using Models;
using Utilities;
using ViewModels.Commands;

namespace ViewModels
{
    public class CategoryBrowserViewModel : BrowserViewModelBase, IInitialBrowserView, ICategoryBrowserViewModel
    {
        private readonly IDatabaseQuerier _querier;
        private readonly IUserInterfaceUpdater _uiUpdater;
        private readonly Categories _categories;

        private IEnumerable<ISeriesPreview> _seriesPreviews;

        public CategoryBrowserViewModel(IDatabaseQuerier querier, IUserInterfaceUpdater uiUpdater, Categories categories, IShowSeriesCommand showSeriesCommand)
        {
            _querier = querier;
            _uiUpdater = uiUpdater;
            _categories = categories;
            ShowSeriesCommand = showSeriesCommand;
            
            /*
            var path = @"C:\Users\Jess\Desktop\Important\Images\Avatars";
            var imagePaths = Directory.GetFiles(path);
            var msp = new SeriesPreview(Guid.NewGuid(), "A Cool Series Name", imagePaths.First(), imagePaths.Length, 0);
            DEBUGSetMangaList(new List<ISeriesPreview> { msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, msp, });
        */
        }
        
        public ICommand ShowSeriesCommand { get; }

        public double SeriesPerRow => 7;

        public double RowsPerPage => 2;
        
        public IEnumerable<ISeriesPreview> SeriesList
        {
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

        public async void ChangeCategoryByIndex(int categoryIndex)
        {
            var seriesResult = await _querier.RunQuery((manager, _) => manager.SeriesManager.GetMangaPreviewsForCategory(categoryIndex), CancellationToken.None);

            if (!seriesResult.Completed)
            {
                return;
            }

            await _uiUpdater.RunOnUi(() =>
            {
                SeriesList = seriesResult.Value;
                OnPropertyChanged(nameof(SeriesList));
            },
            CancellationToken.None,
            (ex) => Console.WriteLine(ex.Message));
        }
    }
}