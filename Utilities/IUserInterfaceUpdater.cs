using System;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities;

public interface IUserInterfaceUpdater
{
    Task RunOnUi(Action action, CancellationToken token, Action<Exception> errorHandler);
}