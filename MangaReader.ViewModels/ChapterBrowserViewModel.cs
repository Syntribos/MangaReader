using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using CommunityToolkit.Mvvm.Input;

using MangaReader.Models;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels;

public class ChapterBrowserViewModel : BrowserViewBase
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