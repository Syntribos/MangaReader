using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaReader.Models
{
    public class MangaFactory : IMangaFactory
    {
        public ISeries Create()
        {
            return new Series(new HashSet<IChapter>(), string.Empty, String.Empty);
        }

        public ISeries CreateDefault()
        {
            return new Series(new HashSet<IChapter>(), string.Empty, String.Empty);
        }
    }
}