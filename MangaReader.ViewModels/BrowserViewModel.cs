using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using MangaReader.DataManager;
using MangaReader.Models.EventArgs;
using MangaReader.ViewModels.Annotations;
using MangaReader.ViewModels.Commands;

using CommunityToolkit.Mvvm.Input;

namespace MangaReader.ViewModels;

public class BrowserViewModel : INotifyPropertyChanged
{
    private readonly IBrowserView _seriesBrowser;
    private readonly IDatabaseQuerier _querier;

    private IBrowserView _currentBrowser;

    public BrowserViewModel(IInitialBrowserView browserView, IShowSeriesCommand showSeriesCommand, IDatabaseQuerier querier)
    {
        _seriesBrowser = browserView;
        _querier = querier;

        _currentBrowser = browserView;
        showSeriesCommand.OnExecute += async (s, e) => await ShowSeries(s, e);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public IBrowserView CurrentBrowser
    {
        get => _currentBrowser;

        private set
        {
            if (value == _currentBrowser)
            {
                return;
            }

            _currentBrowser = value;
            OnPropertyChanged();
        }
    }

    private async Task ShowSeries(object sender, ShowSeriesEventArgs args)
    {
        var seriesResult = await _querier.RunQuery((manager, _) => manager.SeriesManager.BuildSeriesFromPreview(args.SeriesPreview),
            CancellationToken.None);

        if (seriesResult.Completed)
        {
            var chapterBrowserViewModel = new ChapterBrowserViewModel(seriesResult.Value, new RelayCommand(ReturnToSeriesBrowser));
            CurrentBrowser = chapterBrowserViewModel;
        }
    }

    private void ReturnToSeriesBrowser()
    {
        CurrentBrowser = _seriesBrowser;
    }

    [NotifyPropertyChangedInvocator]
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}