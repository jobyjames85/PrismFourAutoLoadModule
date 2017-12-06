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

namespace PrismFourAuto.Account
{
    public partial class NavAccountModule : NavBarGroup, INavBarGroupView
    {
        public NavAccountModule()
        {
            InitializeComponent();
        }

        public string GroupName
        {
            get { return "ModuleA"; }
        }
    }
}
