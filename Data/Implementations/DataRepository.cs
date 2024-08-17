using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading;
using Contract = Utilities.Contract;

namespace Data.Implementations;

public class DataRepository : IDisposable
{
    private readonly IConnectionStringProvider _connectionStringProvider;
    private readonly SQLiteConnection _connection;
    private bool _initialized;

    protected DataRepository(IConnectionStringProvider connectionStringProvider)
    {
        Contract.RequireNotNull(connectionStringProvider, nameof(connectionStringProvider));

        _connectionStringProvider = connectionStringProvider;
        _initialized = false;
        _connection = CreateOrOpenDatabase(_connectionStringProvider);
    }

    public Version Version => new Version(1, 0);
    
    protected bool ExecuteBooleanNonQuery(string query, Parameter parameter)
    {
        return ExecuteBooleanNonQuery(query, new List<Parameter>{ parameter }, (x) => x > 0);
    }
    
    protected bool ExecuteBooleanNonQuery(string query, Parameter parameter, Func<int, bool> validator)
    {
        return ExecuteBooleanNonQuery(query, new List<Parameter>{ parameter }, validator);
    }

    protected bool ExecuteBooleanNonQuery(string query, IEnumerable<Parameter> parameters)
    {
        return ExecuteBooleanNonQuery(query, parameters, (x) => x > 0);
    }

    protected bool ExecuteBooleanNonQuery(string query, IEnumerable<Parameter> parameters, Func<int, bool> predicate)
    {
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

    protected T ExecuteReader<T>(string query, Func<IDataReader, T> itemBuilder)
    {
        return ExecuteReader(query, Enumerable.Empty<Parameter>(), itemBuilder);
    }

    protected T ExecuteReader<T>(string query, Parameter parameter, Func<IDataReader, T> itemBuilder)
    {
        return ExecuteReader(query, new List<Parameter> { parameter }, itemBuilder);
    }

    protected T ExecuteReader<T>(string query, IEnumerable<Parameter> parameters, Func<IDataReader, T> itemBuilder)
    {
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

    protected IEnumerable<T> ExecuteListReader<T>(string query, Parameter parameter, Func<IDataReader, T> itemBuilder, CancellationToken cancellationToken)
    {
        return ExecuteListReader(query, new List<Parameter> { parameter }, itemBuilder, cancellationToken);
    }
    
    protected IEnumerable<T> ExecuteListReader<T>(string query, IEnumerable<Parameter> parameters, Func<IDataReader, T> itemBuilder, CancellationToken cancellationToken)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            _connection.Open();
            var command = _connection.CreateCommand();
            command.CommandText = query;
            
            cancellationToken.ThrowIfCancellationRequested();

            foreach (var item in parameters)
            {
                command.Parameters.AddWithValue(item.Name, item.Value);
            }

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return itemBuilder(reader);
            }
        }
        finally
        {
            _connection.Close();
        }
    }

    public void Dispose()
    {
        _connection.Dispose();
        GC.SuppressFinalize(this);
    }
    
    private SQLiteConnection CreateOrOpenDatabase(IConnectionStringProvider connectionStringProvider)
    {
        if (File.Exists(connectionStringProvider.DatabasePath))
        {
            var connection = new SQLiteConnection(connectionStringProvider.ConnectionString);
            _initialized = true;
            return connection;
        }
        else
        {
            CreateFile(connectionStringProvider.DatabasePath);
        }
        
        var conn = new SQLiteConnection(connectionStringProvider.ConnectionString);
        InitializeDatabase(conn);
        return conn;
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

    private Version GetSchemaVersion(SQLiteConnection conn)
    {
        return ExecuteReader("SELECT major, minor FROM schema", ReadVersion);
    }

    private void InitializeDatabase(SQLiteConnection conn)
    {
        var query =@$"
CREATE TABLE settings (key VARCHAR(20), value VARCHAR(20));
CREATE TABLE schema (major INTEGER, minor INTEGER);
INSERT INTO schema VALUES ({Version.Major}, {Version.Minor})";
        
        try
        {
            conn.Open();
            var command = conn.CreateCommand();
            command.CommandText = query;

            command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }

        _initialized = true;
    }
    
    private static Version ReadVersion(IDataReader reader)
    {
        var major = reader.GetInt32(reader.GetOrdinal("major"));
        var minor = reader.GetInt32(reader.GetOrdinal("minor"));

        return new Version(major, minor);
    }
}