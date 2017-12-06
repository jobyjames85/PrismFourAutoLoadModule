using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.NavigationInfo
{
    public class NavigationModule : IModule
    {
        private IUnityContainer _unityContainer;
        private IRegionManager _regionmanager;

        public NavigationModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionmanager = regionManager;
        }

        public void Initialize()
        {
        }

    }
}
