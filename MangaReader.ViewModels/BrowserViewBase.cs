using System.ComponentModel;
using System.Runtime.CompilerServices;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels;

public class BrowserViewBase : IBrowserView
{
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}