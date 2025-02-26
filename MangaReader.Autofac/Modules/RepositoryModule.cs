using Autofac;
using Data.Implementations;
using Data;
using Scrapers;

namespace MangaReader.Autofac.AutofacModules;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>().SingleInstance();
        builder.RegisterType<ChapterRepository>().As<IChapterRepository>().SingleInstance();
        builder.RegisterType<SeriesRepository>().As<ISeriesRepository>().SingleInstance();
        builder.RegisterType<SettingsRepository>().As<ISettingsRepository>().SingleInstance();
    }
}