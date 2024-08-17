﻿using Autofac;
using Data.Implementations;
using Data;
using Scrapers;
using DataManager.Implementations;
using DataManager;

namespace MangaReader.AutofacModules;

public class ManagerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Manager>().As<IManager>().SingleInstance();
        builder.RegisterType<DatabaseQuerier>().As<IDatabaseQuerier>().SingleInstance();
        builder.RegisterType<SeriesManager>().As<ISeriesManager>().SingleInstance();
        builder.RegisterType<SettingsManager>().As<ISettingsManager>().SingleInstance();
    }
}