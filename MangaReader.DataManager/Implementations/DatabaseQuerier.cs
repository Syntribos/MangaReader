using System;
using System.Threading;
using System.Threading.Tasks;
using MangaReader.Utilities;

namespace MangaReader.DataManager.Implementations;

public class DatabaseQuerier : IDatabaseQuerier, IDisposable
{
    private readonly CancellationTokenSource _cancellationTokenSource;

    public DatabaseQuerier(IManager manager)
    {
        Contract.RequireNotNull(manager, nameof(manager));

        Manager = manager;
        _cancellationTokenSource = new CancellationTokenSource();
    }
    
    public IManager Manager { get; }

    public bool Closed => _cancellationTokenSource.IsCancellationRequested;

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
    }

    public async Task<IQueryResult<T>> RunQuery<T>(Func<IManager, CancellationToken, T> dataFunc, CancellationToken cancellationToken)
    {
        try
        {
            var result = await CreateTask(dataFunc, cancellationToken);

            return new QueryResult<T>(result, true);
        }
        catch
        {
            return QueryResult<T>.CreateNonSuccess();
        }
    }

    private Task<T> CreateTask<T>(Func<IManager, CancellationToken, T> dataFunc, CancellationToken token)
    {
        Contract.RequireNotNull(dataFunc, nameof(dataFunc));
        
        if (Closed)
        {
            return Task.FromResult(default(T));
        }

        var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_cancellationTokenSource.Token, token);

        var task = new Task<T>(() =>
            {
                if (Closed)
                {
                    return default;
                }

                var result = dataFunc(Manager, linkedTokenSource.Token);
                
                if (Closed)
                {
                    return default;
                }
                
                linkedTokenSource.Dispose();
                return result;
            },
            linkedTokenSource.Token);
        
        task.Start(TaskScheduler.Default);
        return task;
    }
}