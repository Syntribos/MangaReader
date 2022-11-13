using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModels.Annotations;

namespace ViewModels;

public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}