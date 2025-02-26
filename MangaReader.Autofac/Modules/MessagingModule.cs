using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using Messaging;

namespace MangaReader.Autofac.Modules;

public class MessagingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EventSubscriptionManager>().As<IEventSubscriptionManager>().SingleInstance();
    }
}
