using System;
using System.Windows.Input;
using Models.CustomEventArgs;

namespace ViewModels.Commands
{
    public interface IShowChapterCommand : ICommand
    {
        event EventHandler<ShowChapterEventArgs> OnExecute;
    }
}
