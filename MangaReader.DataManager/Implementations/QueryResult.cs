namespace MangaReader.DataManager.Implementations;

public class QueryResult<T> : IQueryResult<T>
{
    public QueryResult(T value, bool completed)
    {
        Value = value;
        Completed = completed;
    }
    
    public T Value { get; }
    
    public bool Completed { get; }

    public static IQueryResult<T> CreateNonSuccess()
    {
        return new QueryResult<T>(default, false);
    }
}