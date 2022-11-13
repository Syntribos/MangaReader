using System;
using System.Windows.Input;
using Models.EventArgs;

namespace ViewModels.Commands
{
    public interface IShowSeriesCommand : ICommand
    {
        event EventHandler<ShowSeriesEventArgs> OnExecute;
    }
}
