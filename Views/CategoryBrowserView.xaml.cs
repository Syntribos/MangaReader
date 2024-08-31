using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

using Models;
using ViewModels;

namespace Views
{
    public partial class CategoryBrowserView : UserControl
    {
        public CategoryBrowserView()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Asd");
        }
    }
}