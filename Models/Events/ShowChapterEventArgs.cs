using Models.Events;
using System;

namespace Models.CustomEventArgs;
public class ShowChapterEventArgs : ViewStateChangeEventArgs
{
    public ShowChapterEventArgs(IChapter chapter)
        : base(ViewState.Chapter)
    {
        Chapter = chapter;
    }

    public IChapter Chapter { get; }
}