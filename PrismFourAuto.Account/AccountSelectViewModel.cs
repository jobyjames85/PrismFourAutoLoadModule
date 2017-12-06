using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Account
{
    public class AccountSelectViewModel : ViewModelBase, IRegionMemberLifetime
    {
        public ICommand SwiftToAccountView { get; private set; }

       
        public AccountSelectViewModel()
        {
           
            SwiftToAccountView = new DelegateCommand(NavigateToAccountViewCommand);
        }

        public void ButtonCommand()
        {
            
        }

        private void NavigateToAccountViewCommand()
        {
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            ////Microsoft.Practices.Prism.Regions.IRegion rgn = regionManager.Regions["MainRegion"];
            ////rgn.RequestNavigate("AccountView");
            regionManager.RequestNavigate("MainRegion", "AccountView");
        }
    }
}
