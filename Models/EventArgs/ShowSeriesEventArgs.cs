namespace Models.EventArgs;

public class ShowSeriesEventArgs : System.EventArgs
{
    public ShowSeriesEventArgs(ISeriesPreview preview)
    {
        SeriesPreview = preview;
    }

    public ISeriesPreview SeriesPreview { get; }
}