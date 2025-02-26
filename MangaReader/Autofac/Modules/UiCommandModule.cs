using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels.Commands;
using ViewModels.Commands.CommandImplementations;

using Autofac;

namespace MangaReader.Autofac.Modules;

public class UiCommandModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ShowSeriesCommand>().As<IShowSeriesCommand>().SingleInstance();
    }
}
