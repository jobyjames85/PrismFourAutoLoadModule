using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.Data;
using PrismFourAuto.SharedData;

namespace PrismFourAuto.Staff
{
    [Module(ModuleName = "Staff", OnDemand = true)]
    //[ModuleDependency("NavigationModule")]
    [ModuleDependency("DataModule")]
    [ModuleDependency("ModelModule")]
    [Authorize(Roles = new[] { "user" })]
    //[ModuleDependency("CommonModule")]
    public class StaffModule : IModule
    {
        #region Public Fields

        public IServiceLocator _serviceLocator;

        #endregion Public Fields

        #region Private Fields

        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        #endregion Private Fields

        #region Public Constructors

        public StaffModule(IUnityContainer container, IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            ////container.RegisterType<UserControl, DynamicView>("DynamicView");
            this.container = container;
            this.regionManager = regionManager;
            _serviceLocator = serviceLocator;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize()
        {
            this.container.RegisterType<IManageStaff, ManageStaff>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<object, StaffDetailsView>("StaffDetailsView");
            this.container.RegisterType<object, StaffView>("StaffView");
            this.container.RegisterType<object, InteractionRequestView>("InteractionRequestView");
            //this.container.RegisterType<object, NavigationStaffModule>();
            // Show the Orders Editor view in the shell's main region.
            //this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<StaffView>());
            var view = container.Resolve<StaffSelectView>();
            this.regionManager.Regions["TitleRegion"].Add(view);
            regionManager.RegisterViewWithRegion("HeaderRegion", () => _serviceLocator.GetInstance<StaffSelectView>());

            //this.regionManager.RegisterViewWithRegion("TreeRegion", () => this.container.Resolve<NavigationStaffModule>());
            regionManager.RegisterViewWithRegion("TreeRegion", () => _serviceLocator.GetInstance<NavigationStaffModule>());
            regionManager.RegisterViewWithRegion("NavigationRegion", () => _serviceLocator.GetInstance<NavStaffModule>());
            regionManager.RegisterViewWithRegion("NavigationRegion", typeof(ModuleAItem1View));
            //this.regionManager.RegisterViewWithRegion("HeaderRegion", () => this.container.Resolve<StaffSelectView>());
            // Show the Orders Toolbar view in the shell's toolbar region.
            //this.regionManager.RegisterViewWithRegion("GlobalCommandsRegion", () => this.container.Resolve<OrdersToolBar>());
        }

        #endregion Public Methods
    }
}