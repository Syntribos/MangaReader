using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using MangaReader.Utilities;

namespace MangaReader.MainProject;

public class UserInterfaceUpdater : IUserInterfaceUpdater
{
    private readonly TaskScheduler _uiScheduler;

    public UserInterfaceUpdater(TaskScheduler uiScheduler)
    {
        _uiScheduler = uiScheduler;
    }

    public async Task RunOnUi(Action action, CancellationToken token, Action<Exception> errorHandler)
    {
        try
        {
            await Task.Factory.StartNew(
                () => Application.Current.Dispatcher.BeginInvoke(action),
                token,
                TaskCreationOptions.None,
                _uiScheduler);
        }
        catch (Exception e)
        {
            if (e is TaskCanceledException || e is OperationCanceledException)
            {
                return;
            }

            errorHandler(e);
        }

    }
}