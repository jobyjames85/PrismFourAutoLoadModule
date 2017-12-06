using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.Common;
using PrismFourAuto.Data;
using PrismFourAuto.SharedData;

namespace PrismFourAuto.Account
{
    [Module(ModuleName = "AccountModule", OnDemand = true)]
    //[ModuleDependency("NavigationModule")]
    //[ModuleDependency("CommonModule")]
    [ModuleDependency("DataModule")]
    [Authorize(Roles = new[] { "admin" })]
    public class AccountModule : IModule
    {
        #region Public Fields

        public IServiceLocator _serviceLocator;

        #endregion Public Fields

        #region Private Fields

        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        #endregion Private Fields

        #region Public Constructors

        public AccountModule(IUnityContainer container, IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            this.container = container;
            container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());
            container.RegisterType<object, AccountDetailView>("AccountDetailView");
            container.RegisterType<object, AccountView>("AccountView");
            //container.RegisterType<object, NavAccountModule>("NavAccountModule");
            this.regionManager = regionManager;
            _serviceLocator = serviceLocator;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize()
        {
            //_manager.RegisterViewWithRegion("ContentRegion", typeof (ModuleAView));

            var view = container.Resolve<AccountSelectView>();
            this.regionManager.Regions["TitleRegion"].Add(view);
            regionManager.RegisterViewWithRegion("HeaderRegion", () => _serviceLocator.GetInstance<AccountSelectView>());

            regionManager.RegisterViewWithRegion("SideRegion", () => _serviceLocator.GetInstance<AccountView>());

            regionManager.RegisterViewWithRegion("TreeRegion", () => _serviceLocator.GetInstance<NavigationAccountModule>());
            regionManager.RegisterViewWithRegion("NavigationRegion", () => _serviceLocator.GetInstance<NavAccountModule>());
            regionManager.RegisterViewWithRegion("NavigationRegion", typeof(NavAccountModule));
            //// this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<AccountView>());

            //regionManager.Regions["MainRegion"].Add(view);

            //this.container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());

            // Show the Orders Editor view in the shell's main region.
            ////this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<AccountView>());

            // Show the Orders Toolbar view in the shell's toolbar region.
            //this.regionManager.RegisterViewWithRegion("GlobalCommandsRegion", () => this.container.Resolve<OrdersToolBar>());
        }

        #endregion Public Methods
    }
}