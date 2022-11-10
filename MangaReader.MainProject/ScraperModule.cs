using Autofac;
using MangaReader.Scrapers;

namespace MangaReader.MainProject;

public class ScraperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MangaDexScraper>().SingleInstance();
        builder.RegisterType<ScraperProvider>().SingleInstance().As<IScraperProvider>();
    }
}