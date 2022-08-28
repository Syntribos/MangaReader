using System.ComponentModel;
using System.Runtime.CompilerServices;
using MangaReader.Models.EventArgs;
using MangaReader.ViewModels.Annotations;
using MangaReader.ViewModels.Commands;

namespace MangaReader.ViewModels;

public class BrowserViewModel : INotifyPropertyChanged
{
    private IBrowserView _currentBrowser;

    public BrowserViewModel(IBrowserView browserView, IShowSeriesCommand showSeriesCommand)
    {
        _currentBrowser = browserView;

        showSeriesCommand.OnExecute += ShowSeries;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public IBrowserView CurrentBrowser
    {
        get => _currentBrowser;

        set
        {
            if (value == _currentBrowser)
            {
                return;
            }

            _currentBrowser = value;
            OnPropertyChanged();
        }
    }

    private void ShowSeries(object sender, ShowSeriesEventArgs args)
    {
        var chapterBrowserViewModel = new ChapterBrowserViewModel(args.SeriesPreview);
        CurrentBrowser = chapterBrowserViewModel;
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}