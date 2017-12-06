using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Staff
{
    public class StaffSelectViewModel : ViewModelBase
    {
        #region Public Constructors

        public StaffSelectViewModel()
        {
            SwiftToStaffView = new DelegateCommand(NavigateToStaffViewCommand);
        }

        #endregion Public Constructors

        #region Public Properties

        public ICommand ChangeView { get; private set; }
        public ICommand SwiftToStaffView { get; private set; }

        #endregion Public Properties

        #region Private Methods

        private void NavigateToStaffViewCommand()
        {
            ////container.RegisterType<object, StaffView>("StaffView");
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            //            regionManager.RequestNavigate(Regions["MainRegion"].Add(new StaffView());
            UriQuery objquery = new UriQuery();
            objquery.Add("ID", "1");

            // regionManager.RequestNavigate("MainRegion", new Uri("StaffView"+objquery.ToString(), UriKind.Relative));
            Microsoft.Practices.Prism.Regions.IRegion rgn = regionManager.Regions["MainRegion"];
            rgn.RequestNavigate("StaffDetailsView");
        }

        #endregion Private Methods
    }
}