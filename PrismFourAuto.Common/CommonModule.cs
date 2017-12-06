using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.Common
{
    //[ModuleDependency("NavigationModule")]
    [Module(ModuleName = "CommonModule", OnDemand = true)]
    public class CommonModule : IModule
    {
        #region Private Fields

        private IRegionManager _regionManager;
        private IUnityContainer _unityContainer;

        #endregion Private Fields

        #region Public Constructors

        public CommonModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize()
        {
            _unityContainer.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            //   _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>()
            //.RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }

        #endregion Public Methods
    }
}