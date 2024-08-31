using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Popups;
public interface IPopupBuilder
{
    public bool CanBuild(object popupInfo);

    public bool CanBuild(IPopupInfo popupInfo);

    public IPopup Build(object popupInfo);

    public IPopup Build(IPopupInfo popupInfo);
}
