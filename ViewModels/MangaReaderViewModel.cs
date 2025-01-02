using System;
using CommunityToolkit.Mvvm.Input;
using Models;
using ViewModels.Popups;

namespace ViewModels
{
    public class MangaReaderViewModel : BrowserViewModelBase, IPopup
    {
        private int _currentPageNumber;
        private int _height;
        private int _width;
        
        public MangaReaderViewModel(IChapter mangaInfo, int height, int width)
        {
            ChapterInfo = mangaInfo;
            _currentPageNumber = 0;
            Height = height;
            Width = width;

            NextPageCommand = new RelayCommand(GoToNextPage, CanGoToNextPage);
            PrevPageCommand = new RelayCommand(GoToPrevPage, CanGoToPrevPage);
        }

        public int Height
        {
            get => _height;

            set
            {
                if (_height == value)
                {
                    return;
                }
                
                _height = value;
                OnPropertyChanged();
            }
        }

        public int Width
        {
            get => _width;
            
            set
            {
                if (_width == value)
                {
                    return;
                }
                
                _width = value;
                OnPropertyChanged();
            }
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

        public string ChapterProgress => $"{CurrentPageNumber}/{NumberOfPages + 1}";

        public int NumberOfPages => ChapterInfo.PageCount;

        public string CurrentPage
        {
            get
            {
                return ChapterInfo.GetPagePath(_currentPageNumber);
            }
        }

        public RelayCommand NextPageCommand { get; private set; }

        public RelayCommand PrevPageCommand { get; private set; }

        private void GoToNextPage()
        {
            _currentPageNumber = Math.Min(_currentPageNumber + 1, NumberOfPages);
            UpdatePageInfo();
        }

        private void GoToPrevPage()
        {
            _currentPageNumber = Math.Max(_currentPageNumber - 1, 0);
            UpdatePageInfo();
        }

        private bool CanGoToNextPage()
        {
            return _currentPageNumber < NumberOfPages;
        }

        private bool CanGoToPrevPage()
        {
            return _currentPageNumber > 0;
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

            NextPageCommand.NotifyCanExecuteChanged();
            PrevPageCommand.NotifyCanExecuteChanged();
        }
    }
}