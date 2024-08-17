namespace DataManager;

public interface IDatabaseQuerier
{
    Task<IQueryResult<T?>> RunQuery<T>(Func<IManager, CancellationToken, T> dataReadTask, CancellationToken cancellationToken);
}