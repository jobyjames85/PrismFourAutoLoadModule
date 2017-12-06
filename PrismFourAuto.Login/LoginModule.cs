using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismFourAuto.Data;

namespace PrismFourAuto.Login
{
    //[ModuleDependency("NavigationModule")]
    public class LoginModule : IModule
    {

        private IUnityContainer _unityConatiner;
        private IRegionManager _regionManager;

        public LoginModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityConatiner = unityContainer;
            _regionManager = regionManager;

        }

        public void Initialize()
        {
            this._unityConatiner.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());
            this._unityConatiner.RegisterType<object, LoginView>("LoginView");
            this._regionManager.RegisterViewWithRegion("MainRegion", () => this._unityConatiner.Resolve<LoginView>());
        }

    }
}
