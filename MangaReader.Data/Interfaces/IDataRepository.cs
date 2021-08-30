using System;
using System.Collections.Generic;

namespace MangaReader.Data.Interfaces
{
    public interface IDataRepository : IDisposable
    {
        bool ExecuteBooleanNonQuery(string query, List<Tuple<string, string>> parameters);

        bool ExecuteBooleanNonQuery(string query, List<Tuple<string, string>> parameters, Func<int, bool> predicate);

        Tuple<string, string> CreateParam(string str1, string str2);
    }
}
