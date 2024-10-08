﻿using System;
using System.Windows.Input;
using Models.CustomEventArgs;

namespace ViewModels.Commands
{
    public interface IShowSeriesCommand : ICommand
    {
        event EventHandler<ShowSeriesEventArgs> OnExecute;
    }
}
