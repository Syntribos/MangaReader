using Models;
using System;

namespace ViewModels.Events;

public class ShowChapterEventArgs : ShowPopupEventArgs
{
    public ShowChapterEventArgs(IChapter chapter)
        : base(Popup.Chapter)
    {
        Chapter = chapter;
    }

    public IChapter Chapter { get; }
}