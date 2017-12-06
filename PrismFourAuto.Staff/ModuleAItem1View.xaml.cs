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
    /// Interaction logic for ModuleAItem1View.xaml
    /// </summary>
    public partial class ModuleAItem1View : NavBarItem, INavBarItemView
    {
        public ModuleAItem1View()
        {
            InitializeComponent();
        }

        public string GroupName
        {
            get { return "ModuleA"; }
        }
    }
}
