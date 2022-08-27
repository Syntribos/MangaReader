using System.ComponentModel;
using System.Runtime.CompilerServices;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}