using Models.Events;
using System;

namespace Models.CustomEventArgs;
public class ShowChapterEventArgs : ShowPopupEventArgs
{
    public ShowChapterEventArgs(IChapter chapter)
        : base(Popup.Chapter)
    {
        Chapter = chapter;
    }

    public IChapter Chapter { get; }
}