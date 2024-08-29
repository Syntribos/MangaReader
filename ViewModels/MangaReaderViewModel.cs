using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Models;
using ViewModels.Annotations;

namespace ViewModels
{
    public class MangaReaderViewModel : BrowserViewModelBase, IPopup
    {
        private int _currentPageNumber;
        
        public MangaReaderViewModel(IChapter mangaInfo)
        {
            ChapterInfo = mangaInfo;
            _currentPageNumber = 0;

            NextPageCommand = new RelayCommand(GoToNextPage, CanGoToNextPage);
            PrevPageCommand = new RelayCommand(GoToPrevPage, CanGoToPrevPage);
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

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}