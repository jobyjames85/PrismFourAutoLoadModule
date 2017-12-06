using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismFourAuto.Account
{
    public partial class NavigationAccountModule : TreeViewItem
    {
        public NavigationAccountModule(NavigationAccountModuleViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        static NavigationAccountModule()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationAccountModule), new FrameworkPropertyMetadata(typeof(ItemsControl)));
        }
    }
}
