using Autofac;
using Scrapers;
using Scrapers.MangaDex;

namespace MangaReader.Autofac.AutofacModules;

public class ScraperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApiClientProvider>().SingleInstance().AsImplementedInterfaces();
        builder.RegisterType<MangaDexScraper>().SingleInstance().AsImplementedInterfaces();
        builder.RegisterType<ScraperProvider>().SingleInstance().AsImplementedInterfaces();
    }
}