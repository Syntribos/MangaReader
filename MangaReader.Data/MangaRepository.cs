using MangaReader.Data.Interfaces;
using MangaReader.Models;
using System.Collections.Generic;

namespace MangaReader.Data
{
    public class MangaRepository : DataRepository, IMangaRepository
    {
        public MangaRepository(string databasePath)
            : base(databasePath)
        {
        }

        public IEnumerable<Manga> GetAllManga()
        {
            yield return ReadMangaData();
        }

        public IEnumerable<Manga> GetMangaForCategory(string category)
        {
            yield return ReadMangaData();
        }

        private static Manga ReadMangaData()
        {
            return new Manga();
        }
    }
}