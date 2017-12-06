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
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;

namespace PrismFourAuto.Staff
{
    /// <summary>
    /// Interaction logic for StaffView.xaml
    /// </summary>
    public partial class StaffView : UserControl
    {
        public StaffView(StaffViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            var regionContext = RegionContext.GetObservableContext(this);
            regionContext.PropertyChanged += RegionContextOnPropertyChanged;
        }

        private void RegionContextOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var observableObject = sender as ObservableObject<object>;
            if (observableObject != null && observableObject.Value != null)
            {
                // Get the GUID value from the context and pass to the VM
                // (assuming the VM has a method called SetGuid().
                var myGuid = (Guid)observableObject.Value;
                (DataContext as StaffViewModel).SetGuid(myGuid);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
