using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Popups;
public class PopupHostViewModel : BrowserViewModelBase, IPopup
{
    public PopupHostViewModel(IPopup popup)
    {
        Popup = popup;
    }

    public IPopup Popup { get; set; }
    
    public int Height { get; set; }
    
    public int Width { get; set; }
}
