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

namespace PrismFourAuto.Staff
{
    /// <summary>
    /// Interaction logic for NavigationStaffModule.xaml
    /// </summary>
    public partial class NavigationStaffModule : TreeViewItem
    {
        public NavigationStaffModule(NavigationStaffModuleViewModel viewModel)
        {
            InitializeComponent();
            ////this.DataContext = viewModel;
            //this.Items.Add("Hello test");
            //this.Items.Add("Hello test1");
            this.DataContext = viewModel;
        }

        static NavigationStaffModule()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationStaffModule), new FrameworkPropertyMetadata(typeof(ItemsControl)));
        }

    }
}
