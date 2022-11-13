using System;
using MangaReader.Models;
using MangaReader.Models.EventArgs;

namespace MangaReader.ViewModels.Commands.CommandImplementations
{
    public class ShowSeriesCommand : IShowSeriesCommand
    {
        public event EventHandler CanExecuteChanged;

        public event EventHandler<ShowSeriesEventArgs> OnExecute;

        public bool CanExecute(object parameter)
        {
            return parameter is ISeriesPreview;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is ISeriesPreview preview))
            {
                return;
            }

            var message = new ShowSeriesEventArgs(preview);
            OnExecute?.Invoke(this, message);
        }
    }
}
