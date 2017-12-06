using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI.Navigation;
using Microsoft.Practices.Prism.Regions;

namespace PrismFourAuto
{
    public class MainFrameNavigationViewModel : PrismFourAuto.NavigationInfo.ViewModelBase
    {

        private IRegionNavigationService navigationService;

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            if (navigationContext.Parameters != null && navigationContext.Parameters.Count() > 0)
            {
                var id = navigationContext.Parameters;
            }
            base.OnNavigatedTo(navigationContext);
            navigationService = navigationContext.NavigationService;
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return base.IsNavigationTarget(navigationContext);
        }

        ////bool Microsoft.Practices.Prism.Regions.INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////void Microsoft.Practices.Prism.Regions.INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////void Microsoft.Practices.Prism.Regions.INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        ////{
        ////    throw new NotImplementedException();
        ////}
    }
}
