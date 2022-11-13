namespace DataManager;

public interface IQueryResult<T>
{
    public T Value { get; }
    
    public bool Completed { get; }
}