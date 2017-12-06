using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.Data
{
    [Module(ModuleName = "DataModule", OnDemand = false)]
    //[ModuleDependency("NavigationModule")]
    [ModuleDependency("ModelModule")]
    public class DataModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public DataModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {

            //_manager.RegisterViewWithRegion("ContentRegion", typeof (ModuleAView));

            container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());

            //this.container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());

            // Show the Orders Editor view in the shell's main region.
            //this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<StaffView>());

            // Show the Orders Toolbar view in the shell's toolbar region.
            //this.regionManager.RegisterViewWithRegion("GlobalCommandsRegion", () => this.container.Resolve<OrdersToolBar>());
        }
    }
}
