using MangaReader.Data.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace MangaReader.Data
{
    public class DataRepository : IDataRepository
    {
        protected readonly string _connectionString;
        protected readonly SqliteConnection _connection;
        protected bool _initialized;

        public DataRepository(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};";
            _connection = new SqliteConnection(_connectionString);
            _initialized = false;

            if (!File.Exists(databasePath))
            {
                CreateFile(databasePath);
                InitializeDatabase();
            }
        }

        public bool ExecuteBooleanNonQuery(string query, List<Tuple<string, string>> parameters)
        {
            return ExecuteBooleanNonQuery(query, parameters, (x) => x > 0);
        }

        public bool ExecuteBooleanNonQuery(string query, List<Tuple<string, string>> parameters, Func<int, bool> predicate)
        {
            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = query;

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Item1, item.Item2);
                }

                return predicate(command.ExecuteNonQuery());
            }
            finally
            {
                _connection.Close();
            }
        }

        public Tuple<string, string> CreateParam(string str1, string str2)
        {
            return Tuple.Create(str1, str2);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        protected void EnsureInitialization()
        {
            if (!_initialized)
            {
                throw new NotSupportedException("Data repository must be initialized before use.");
            }
        }

        private static void CreateFile(string path)
        {
            var fi = new FileInfo(path);

            if (fi.Directory == null)
            {
                throw new ArgumentException($"Directory {path} does not exist.");
            }

            Directory.CreateDirectory(fi.Directory.FullName);
            File.Create(Path.GetFileName(path));
        }

        private void InitializeDatabase()
        {
            ExecuteBooleanNonQuery(
                @"
                    put db schema here
                ",
                new List<Tuple<string, string>>
                {
                }
            );
        }
    }
}