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

namespace PrismFourAuto
{
    /// <summary>
    /// Interaction logic for MainFrameNavigate.xaml
    /// </summary>
    public partial class MainFrameNavigate : UserControl
    {
        #region Public Constructors

        public MainFrameNavigate()
        {
            InitializeComponent();
        }

        public MainFrameNavigate(MainFrameNavigationViewModel viewModel)
            : this()
        {
            this.DataContext = viewModel;
        }

        #endregion Public Constructors
    }
}