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
            return new Manga();
        }
    }
}