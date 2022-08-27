using System.ComponentModel;
using System.Runtime.CompilerServices;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels;

public class BrowserViewModel : INotifyPropertyChanged
{
    private IBrowserView _currentBrowser;

    public BrowserViewModel(IBrowserView browserView)
    {
        _currentBrowser = browserView;
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

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}