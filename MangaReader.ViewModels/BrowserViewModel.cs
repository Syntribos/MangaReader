using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MangaReader.Data.Interfaces;
using MangaReader.Models.EventArgs;
using MangaReader.ViewModels.Annotations;
using MangaReader.ViewModels.Commands;

namespace MangaReader.ViewModels;

public class BrowserViewModel : INotifyPropertyChanged
{
    private readonly IBrowserView _seriesBrowser;
    private readonly ISeriesRepository _seriesRepository;

    private IBrowserView _currentBrowser;

    public BrowserViewModel(IBrowserView browserView, IShowSeriesCommand showSeriesCommand, ISeriesRepository seriesRepository)
    {
        _seriesBrowser = browserView;
        _seriesRepository = seriesRepository;
        _currentBrowser = browserView;

        showSeriesCommand.OnExecute += async (s, e) => await ShowSeries(s, e);
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

    private async Task ShowSeries(object sender, ShowSeriesEventArgs args)
    {
        var series = await Task.Factory.StartNew(() => _seriesRepository.BuildSeriesFromPreview(args.SeriesPreview));
        var chapterBrowserViewModel = new ChapterBrowserViewModel(series, new RelayCommand(ReturnToSeriesBrowser));
        CurrentBrowser = chapterBrowserViewModel;
    }

    private void ReturnToSeriesBrowser()
    {
        CurrentBrowser = _seriesBrowser;
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}