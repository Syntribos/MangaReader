using MangaReader.Data.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MangaReader.Data
{
    public class DataRepository : IDisposable
    {
        private readonly string _connectionString;
        private readonly SqliteConnection _connection;
        private bool _initialized;

        protected DataRepository(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};";
            _connection = new SqliteConnection(_connectionString);
            _initialized = false;

            if (!File.Exists(databasePath))
            {
                CreateFile(databasePath);
                InitializeDatabase();
            }
            else
            {
                _initialized = true;
            }
        }
        
        protected bool ExecuteBooleanNonQuery(string query, (string Name, string Value) parameter)
        {
            return ExecuteBooleanNonQuery(query, new List<(string ParameterName, string Value)>{ parameter }, (x) => x > 0);
        }
        
        protected bool ExecuteBooleanNonQuery(string query, (string Name, string Value) parameter, Func<int, bool> validator)
        {
            return ExecuteBooleanNonQuery(query, new List<(string ParameterName, string Value)>{ parameter }, validator);
        }

        protected bool ExecuteBooleanNonQuery(string query, IEnumerable<(string Name, string Value)> parameters)
        {
            return ExecuteBooleanNonQuery(query, parameters, (x) => x > 0);
        }

        protected bool ExecuteBooleanNonQuery(string query, IEnumerable<(string Name, string Value)> parameters, Func<int, bool> predicate)
        {
            EnsureInitialization();

            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = query;

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Name, item.Value);
                }

                return predicate(command.ExecuteNonQuery());
            }
            finally
            {
                _connection.Close();
            }
        }

        protected T ExecuteReader<T>(string query, IEnumerable<(string Name, string Value)> parameters, Func<IDataReader, T> itemBuilder)
        {
            EnsureInitialization();

            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = query;

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Name, item.Value);
                }

                var reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    throw new InvalidOperationException("No results from query.");
                }

                return itemBuilder(reader);
            }
            finally
            {
                _connection.Close();
            }
        }

        protected IEnumerable<T> ExecuteListReader<T>(string query, (string Name, string Value) parameter,
            Func<IDataReader, T> itemBuilder)
        {
            return ExecuteListReader(query, new List<(string Name, string Value)> { parameter }, itemBuilder);
        }


        protected IEnumerable<T> ExecuteListReader<T>(string query, IEnumerable<(string Name, string Value)> parameters, Func<IDataReader, T> itemBuilder)
        {
            EnsureInitialization();

            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = query;

                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Name, item.Value);
                }

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return itemBuilder(reader);
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        protected static (string Name, string Value) CreateParam(string str1, string str2)
        {
            return (str1, str2);
        }

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        private void EnsureInitialization()
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
                new List<(string, string)>
                {
                }
            );

            _initialized = true;
        }
    }
}