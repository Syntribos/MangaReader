using System;
using System.Collections.Generic;

using MangaReader.Data.Interfaces;
using MangaReader.Models;

namespace MangaReader.Data
{
    public class SeriesRepository : ChapterRepository, ISeriesRepository
    {
        private readonly IMangaFactory _mangaFactory;

        public SeriesRepository(MangaFactory mangaFactory, string databasePath)
            : base(databasePath)
        {
            _mangaFactory = mangaFactory;
        }

        public void SaveManga(Series manga)
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

        public IEnumerable<ISeries> GetMangaForCategory(int categoryIndex)
        {
            yield return ReadMangaData();
        }

        private ISeries ReadMangaData()
        {
            return _mangaFactory.Create();
        }
    }
}