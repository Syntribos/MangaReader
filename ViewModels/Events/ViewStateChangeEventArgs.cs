using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Events;
public class ViewStateChangeEventArgs : EventArgs
{
    public ViewStateChangeEventArgs(ViewState state)
    {
        State = state;
    }

    public ViewState State { get; }
}

public delegate Task ViewStateChangeRequestHandler(object sender, ViewStateChangeEventArgs e);
