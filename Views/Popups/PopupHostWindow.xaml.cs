using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels;

namespace Views.Popups;
/// <summary>
/// Interaction logic for PopupHostWindow.xaml
/// </summary>
public partial class PopupHostWindow : Window
{
    public PopupHostWindow(IPopup popup)
    {
        DataContext = popup;
        InitializeComponent();
    }
}
