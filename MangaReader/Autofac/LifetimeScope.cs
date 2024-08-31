using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Popups;
using Views.Popups;

namespace MangaReader.Autofac;
internal class LifetimeScope
{
    private readonly HashSet<object> _held;

    public LifetimeScope()
    {
        _held = new HashSet<object>();
    }

    internal void BuildLifetime(IContainer container)
    {
        _held.Add(container.Resolve<IPopupManager>());
    }
}
