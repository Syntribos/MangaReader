﻿using Autofac;
using Data.Implementations;
using Data;
using Scrapers;

namespace MangaReader.AutofacModules;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ChapterRepository>().As<IChapterRepository>().SingleInstance();
        builder.RegisterType<SeriesRepository>().As<ISeriesRepository>().SingleInstance();
        builder.RegisterType<SettingsRepository>().As<ISettingsRepository>().SingleInstance();
    }
}