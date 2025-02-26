using System;
using System.Windows.Input;

using Models.CustomEventArgs;
using ViewModels.Events;

namespace ViewModels.Commands
{
    public interface IShowChapterCommand : ICommand
    {
        event EventHandler<ShowChapterEventArgs> OnExecute;
    }
}
