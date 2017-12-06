using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.SharedData
{
    [Module(ModuleName = "SharedDataModule", OnDemand = false)]
    [ModuleDependency("DataModule")]
    public class SharedDataModule : IModule
    {
        #region Private Fields

        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        #endregion Private Fields

        #region Public Constructors

        public SharedDataModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize()
        {
            //_manager.RegisterViewWithRegion("ContentRegion", typeof (ModuleAView));

            // container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());

            //this.container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());

            // Show the Orders Editor view in the shell's main region.
            //this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<StaffView>());

            // Show the Orders Toolbar view in the shell's toolbar region.
            //this.regionManager.RegisterViewWithRegion("GlobalCommandsRegion", () => this.container.Resolve<OrdersToolBar>());
        }

        #endregion Public Methods
    }
}