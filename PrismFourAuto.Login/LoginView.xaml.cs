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

namespace PrismFourAuto.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        #region Public Constructors

        public LoginView()
        {
            InitializeComponent();
        }

        public LoginView(LoginViewModel viewModel)
            : this()
        {
            this.DataContext = viewModel;
        }

        #endregion Public Constructors
    }
}