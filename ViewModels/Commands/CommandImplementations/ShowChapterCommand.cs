using System;
using Models;
using Models.CustomEventArgs;

namespace ViewModels.Commands.CommandImplementations
{
    public class ShowChapterCommand : IShowChapterCommand
    {
        public event EventHandler CanExecuteChanged;

        public event EventHandler<ShowChapterEventArgs> OnExecute;

        public bool CanExecute(object parameter)
        {
            return parameter is IChapter;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is IChapter chapter))
            {
                return;
            }

            var message = new ShowChapterEventArgs(chapter);
            OnExecute?.Invoke(this, message);
        }
    }
}
