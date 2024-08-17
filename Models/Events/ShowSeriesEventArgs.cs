using Models.Events;
using System;

namespace Models.CustomEventArgs;
public class ShowSeriesEventArgs : ViewStateChangeEventArgs
{
    public ShowSeriesEventArgs(ISeriesPreview preview)
        : base(ViewState.Series)
    {
        SeriesPreview = preview;
    }

    public ISeriesPreview SeriesPreview { get; }
}