using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModels.Annotations;

namespace ViewModels;

public class BrowserViewModelBase : IBrowserView
{
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}