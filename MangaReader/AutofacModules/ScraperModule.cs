using Autofac;
using Scrapers;

namespace MangaReader.AutofacModules;

public class ScraperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MangaDexScraper>().SingleInstance().As<IScraper>();
        builder.RegisterType<ScraperProvider>().SingleInstance().As<IScraperProvider>();
    }
}