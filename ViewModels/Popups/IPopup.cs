using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Popups;
public interface IPopup : IBrowserView
{
    int Height { get; set; }
    
    int Width { get; set; }
}
