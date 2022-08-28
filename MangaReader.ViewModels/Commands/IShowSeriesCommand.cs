using System;
using System.Windows.Input;
using MangaReader.Models.EventArgs;

namespace MangaReader.ViewModels.Commands
{
    public interface IShowSeriesCommand : ICommand
    {
        event EventHandler<ShowSeriesEventArgs> OnExecute;
    }
}
