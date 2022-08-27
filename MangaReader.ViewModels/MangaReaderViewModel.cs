using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using MangaReader.Models;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels
{
    public class MangaReaderViewModel : INotifyPropertyChanged
    {
        private int _currentPageNumber;
        
        public MangaReaderViewModel(IChapter mangaInfo)
        {
            ChapterInfo = mangaInfo;
            _currentPageNumber = 0;
        }

        public IChapter ChapterInfo { get; }

        public int CurrentPageNumber
        {
            get => _currentPageNumber + 1;

            set
            {
                _currentPageNumber = value;
                UpdatePageInfo();
            }
        }

        public string ChapterProgress => $"{CurrentPageNumber}/{NumberOfPages}";

        public int NumberOfPages => ChapterInfo.PageCount;

        public string CurrentPage => ChapterInfo.GetPagePath(_currentPageNumber);

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoToNextPage()
        {
            _currentPageNumber = Math.Min(_currentPageNumber + 1, NumberOfPages);
            UpdatePageInfo();
        }
        
        public void GoToPreviousPage()
        {
            _currentPageNumber = Math.Max(_currentPageNumber - 1, 0);
            UpdatePageInfo();
        }

        public void GoToPage(int pageNumber)
        {
            _currentPageNumber = pageNumber;
            UpdatePageInfo();
        }

        private void UpdatePageInfo()
        {
            OnPropertyChanged(nameof(CurrentPageNumber));
            OnPropertyChanged(nameof(CurrentPage));
            OnPropertyChanged(nameof(ChapterProgress));
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}