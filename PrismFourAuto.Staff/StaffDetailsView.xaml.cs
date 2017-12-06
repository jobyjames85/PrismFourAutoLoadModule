﻿using System;
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
    /// Interaction logic for StaffDetailsView.xaml
    /// </summary>
    public partial class StaffDetailsView : UserControl
    {
        public StaffDetailsView(StaffDetailsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
