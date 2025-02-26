using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.CustomEventArgs;
using ViewModels.Events;

namespace ViewModels.Managers;
public interface IViewStateManager
{
    event ViewStateChangeRequestHandler ViewStateChangeRequest;
}
