using System;
using System.Threading;
using System.Threading.Tasks;

namespace MangaReader.DataManager;

public interface IDatabaseQuerier
{
    Task<IQueryResult<T>> RunQuery<T>(Func<IManager, CancellationToken, T> dataReadTask, CancellationToken cancellationToken);
}