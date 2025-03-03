﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Events;

public class ShowPopupEventArgs : EventArgs
{
    public ShowPopupEventArgs(Popup popupType)
    {
        PopupType = popupType;
    }

    public Popup PopupType { get; init; }
}
