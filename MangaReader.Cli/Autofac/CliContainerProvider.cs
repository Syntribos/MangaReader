using Autofac;
using MangaReader.Autofac;
using Utilities;

namespace MangaReader.Cli.Autofac;

internal class CliContainerProvider
{
    public static IContainer BuildCliContainer()
    {
        var builder = SharedContainerProvider.CreateSharedBuilder();

        builder.RegisterType<VersionProvider>()
            .AsImplementedInterfaces()
            .SingleInstance();

        return builder.Build();
    }
}
