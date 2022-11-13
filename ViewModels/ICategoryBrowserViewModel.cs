using System.Collections.Generic;
using System.Windows.Input;
using Models;

namespace ViewModels;

public interface ICategoryBrowserViewModel
{
    ICommand ShowSeriesCommand { get; }

    double SeriesPerRow { get; }

    double RowsPerPage { get; }

    void DEBUGSetMangaList(IEnumerable<ISeriesPreview> seriesList);

    void ChangeCategoryByName(string categoryName);

    void ChangeCategoryByIndex(int categoryIndex);
}