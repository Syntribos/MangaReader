using System.Windows.Controls;

namespace Views;

public partial class BrowserView : UserControl
{
    public BrowserView()
    {
        InitializeComponent();


        MyBox.SelectedItem = null;
    }
}