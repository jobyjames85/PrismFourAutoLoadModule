using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.Model
{
     //[ModuleDependency("NavigationModule")]
    public class ModelModule : IModule
    {
       
        private IUnityContainer _unityContainer;
        private IRegionManager _regionManager;
        public ModelModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _unityContainer.RegisterType<IUnitOfWork, UnitOfWork>()
          .RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
