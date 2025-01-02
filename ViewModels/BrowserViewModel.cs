using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using DataManager;
using Models.CustomEventArgs;
using CommunityToolkit.Mvvm.Input;
using ViewModels.Annotations;
using ViewModels.Commands;
using ViewModels.Managers;
using Models.Events;
using System.Windows.Input;
using Models;
using System.IO;
using System.Xml.Linq;

namespace ViewModels;

public class BrowserViewModel : INotifyPropertyChanged
{
    private readonly IBrowserView _seriesBrowser;
    private readonly IDatabaseQuerier _querier;
    private readonly IViewStateManager _viewStateManager;
    private readonly IEventSubscriptionManager _eventSubscriptionManager;

    private IBrowserView _currentBrowser;

    public BrowserViewModel(IInitialBrowserView browserView, IViewStateManager viewStateManager, IDatabaseQuerier querier, IEventSubscriptionManager eventSubscriptionManager)
    {
        _seriesBrowser = browserView;
        _querier = querier;
        _viewStateManager = viewStateManager;
        _eventSubscriptionManager = eventSubscriptionManager;
        Debugton = new RelayCommand(Debbie);

        _viewStateManager.ViewStateChangeRequest += ViewStateChanged;

        _currentBrowser = browserView;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand Debugton { get; init; }

    public string blocked_type { get; set; }

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

    private async void Debbie()
    {
        var path = @"C:\Users\Jess\.runelite\screenshots\Kambabam\Clue Scroll Rewards";
        var imagePaths = Directory.GetFiles(path);
        var mc = new MangaChapter("Chapter Gay", 17, path, imagePaths);
        await _eventSubscriptionManager.Publish(this, new ShowChapterEventArgs(mc));
    }

    private Task ViewStateChanged(object sender, ViewStateChangeEventArgs args)
    {
        return Task.CompletedTask;
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