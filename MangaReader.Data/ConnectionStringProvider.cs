using System.Data.SQLite;
using MangaReader.Utilities;

namespace MangaReader.Data;

public class ConnectionStringProvider : IConnectionStringProvider
{
    public ConnectionStringProvider(string path)
    {
        Contract.RequireNotNullOrEmpty(path);

        DatabasePath = path;
        ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = path, }.ToString();
    }
    
    public string DatabasePath { get; }
    
    public string ConnectionString { get; }
}