using System;
using System.Windows.Input;

using MangaReader.Models;

namespace MangaReader.ViewModels.Commands
{
    public class ShowSeriesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

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
            
            Console.WriteLine(preview.ToString());
        }
    }
}
