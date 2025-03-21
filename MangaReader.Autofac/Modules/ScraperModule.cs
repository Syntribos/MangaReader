﻿using Autofac;
using Scrapers;
using Scrapers.MangaDex;

namespace MangaReader.Autofac.AutofacModules;

public class ScraperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApiClient>()
            .OnActivating(e => e.Instance.Init())
            .SingleInstance();
        builder.RegisterType<MangaDexScraper>().SingleInstance().As<IScraper>();
        builder.RegisterType<ScraperProvider>().SingleInstance().As<IScraperProvider>();
    }
}