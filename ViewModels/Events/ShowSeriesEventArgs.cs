using Models;
using System;

namespace ViewModels.Events;
public class ShowSeriesEventArgs : ViewStateChangeEventArgs
{
    public ShowSeriesEventArgs(ISeriesPreview preview)
        : base(ViewState.Series)
    {
        SeriesPreview = preview;
    }

    public ISeriesPreview SeriesPreview { get; }
}