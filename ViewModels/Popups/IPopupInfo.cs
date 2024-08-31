using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Popups;
public interface IPopupInfo
{
    public Popup PopupType { get; }

    public IChapter ToChapter();
}
