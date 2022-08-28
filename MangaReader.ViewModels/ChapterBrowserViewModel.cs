using System.ComponentModel;
using System.Runtime.CompilerServices;
using MangaReader.Models;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels;

public class ChapterBrowserViewModel : BrowserViewBase
{
    private readonly ISeriesPreview _seriesPreview;

    public ChapterBrowserViewModel(ISeriesPreview preview)
    {
        _seriesPreview = preview;
    }

    public string Name => _seriesPreview.Title;
}