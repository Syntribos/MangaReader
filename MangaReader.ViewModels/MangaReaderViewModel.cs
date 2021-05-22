using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MangaReader.Models;
using MangaReader.ViewModels.Annotations;

namespace MangaReader.ViewModels
{
    public class MangaReaderViewModel : INotifyPropertyChanged
    {
        public MangaReaderViewModel(MangaInfo mangaInfo)
        {
            ChapterInfo = mangaInfo;
        }

        public MangaInfo ChapterInfo { get; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}