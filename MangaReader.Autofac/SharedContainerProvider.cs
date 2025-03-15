using Autofac;
using MangaReader.Autofac.AutofacModules;
using MangaReader.Autofac.Modules;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaReader.Autofac;

public class SharedContainerProvider
{
    public static ContainerBuilder CreateSharedBuilder()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<Categories>().SingleInstance();

        RegisterSharedModules(builder);

        return builder;
    }

    public static void RegisterSharedModules(ContainerBuilder builder)
    {
        builder.RegisterModule<MessagingModule>();
        builder.RegisterModule<RepositoryModule>();
        builder.RegisterModule<ManagerModule>();
        builder.RegisterModule<ScraperModule>();
    }
}
