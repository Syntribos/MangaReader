using System;
using System.Collections.Generic;

using MangaReader.Data.Interfaces;
using MangaReader.Models;

namespace MangaReader.Data
{
    public class MangaRepository : ChapterRepository, IMangaRepository
    {
        private readonly IMangaFactory _mangaFactory;

        public MangaRepository(MangaFactory mangaFactory, string databasePath)
            : base(databasePath)
        {
            _mangaFactory = mangaFactory;
        }

        public void SaveManga(Manga manga)
        {
            const string query = @"
                INSERT INTO []
                ()
                VALUES (@mangaInfo)";

            base.ExecuteBooleanNonQuery(query, new List<System.Tuple<string, string>> { new Tuple<string, string>("@mangaInfo", manga.AsDatabaseString()) });
        }

        public IEnumerable<ISeries> GetAllManga()
        {
            yield return ReadMangaData();
        }

        public IEnumerable<ISeries> GetMangaForCategory(string category)
        {
            yield return ReadMangaData();
        }

        private ISeries ReadMangaData()
        {
            return _mangaFactory.Create();
        }
    }
}