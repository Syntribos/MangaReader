using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels.Popups;
public class PopupBuilder : IPopupBuilder
{
    public bool CanBuild(object popupInfo)
    {
        return popupInfo is IPopupInfo info && CanBuild(info);
    }

    public bool CanBuild(IPopupInfo popupInfo)
    {
        throw new NotImplementedException();
    }

    public IPopup Build(object popupInfo)
    {
        return popupInfo is IPopupInfo info ? Build(info) : null;
    }

    public IPopup Build(IPopupInfo popupInfo)
    {
        if (popupInfo.PopupType is Popup.Chapter)
        {
            return new MangaReaderViewModel(popupInfo.ToChapter(), 1000, 480);
        }

        return null;
    }
}
