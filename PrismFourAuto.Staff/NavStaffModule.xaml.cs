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
using DevExpress.Xpf.NavBar;
using NavBarControlAdapter;

namespace PrismFourAuto.Staff
{
    /// <summary>
    /// Interaction logic for NavStaffModule.xaml
    /// </summary>
    public partial class NavStaffModule : NavBarGroup, INavBarGroupView
    {
        public NavStaffModule()
        {
            InitializeComponent();
        }

        public string GroupName
        {
            get { return "ModuleB"; }
        }
    }
}
