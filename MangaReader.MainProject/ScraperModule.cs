using System;
using Autofac;
using MangaReader.Scrapers;

namespace MangaReader.MainProject;

public class ScraperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MangaDexScraper>().SingleInstance().As<IScraper>();
        builder.RegisterType<ScraperProvider>().SingleInstance().As<IScraperProvider>();
    }
}