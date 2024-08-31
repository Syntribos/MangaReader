using Models;
using Models.CustomEventArgs;
using Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Popups;
public class PopupInfo : IPopupInfo
{
    private readonly object _parameters;

    private PopupInfo(object parameters, Popup popupType)
    {
        _parameters = parameters;
        PopupType = popupType;
    }

    public Popup PopupType { get; init; }

    public IChapter ToChapter()
    {
        return _parameters as IChapter;
    }

    public static IPopupInfo FromEventArgs(ShowPopupEventArgs args)
    {
        switch (args)
        {
            case ShowChapterEventArgs:
                return new PopupInfo((args as ShowChapterEventArgs).Chapter, Popup.Chapter);

            default:
                throw new ArgumentException();
        }
    }

    public static IPopupInfo FromParameters(object parameters)
    {
        if (parameters is IChapter chapter)
        {
            return new PopupInfo(chapter, Popup.Chapter);
        }

        throw new ArgumentException($"Failed to build PopupInfo from {parameters?.ToString() ?? null}.");
    }
}
