using CommunityToolkit.Mvvm.Input;

using Models;

namespace ViewModels;

public class ChapterBrowserViewModel : BrowserViewModelBase
{
    private readonly ISeries _seriesPreview;

    public ChapterBrowserViewModel(ISeries preview, RelayCommand goBackCommand)
    {
        _seriesPreview = preview;
        GoBackCommand = goBackCommand;
    }

    public RelayCommand GoBackCommand { get; }

    public string Name => _seriesPreview.Title;
}