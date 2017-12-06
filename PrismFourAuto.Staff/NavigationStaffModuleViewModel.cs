using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.Staff
{
    public class NavigationStaffModuleViewModel : PrismFourAuto.NavigationInfo.ViewModelBase
    {

        IRegionManager _regionManager;
        public DelegateCommand<object> SelectedCommand { get; private set; }
        public NavigationStaffModuleViewModel()
        {
            SelectedCommand = new DelegateCommand<object>(SelectedExecute, CanExecuteSelected);
            _categories = new ObservableCollection<EntityBase>();
            Categories.Add(new EntityBase() { Title = "StaffDetailsView", });
            Categories.Add(new EntityBase() { Title = "StaffView" });
        }

        public EntityBase CurrentCategory { get; private set; }

        private ObservableCollection<EntityBase> _categories;
        public ObservableCollection<EntityBase> Categories { get { return _categories; } }

        private EntityBase _root;
        public EntityBase Root // Populate in NavigationDocumentsViewModel_PropertyChanged
        {
            get { return _root ?? new Catalog() { Title = "Staff" }; }
            set
            {
                if (value != _root)
                {
                    _root = value;
                    this.OnPropertyChanged("Root");
                }
            }
        }

        private bool CanExecuteSelected(object arg)
        {
            return true;
        }

        private void SelectedExecute(object obj1)
        {
            if (obj1 == null)
            {
                return;
                ////EntityBase obj = obj1 as EntityBase;
                ////if (obj != null)
                ////{
                ////    Catalog cat = obj as Catalog;
                ////    if (cat != null)
                ////    {
                ////        string addressView = QueryStringBuilder.Construct(ViewsName.CatalogView, new[,] { { ViewsName.ParentId, obj.IDEntity.ToString() } });
                ////        _regionManager.RequestNavigate(NameRegions.MainRegion, addressView, Callback);
                ////    }
                ////    else
                ////    {
                ////        _regionManager.RequestNavigate(NameRegions.MainRegion, QueryStringBuilder.Construct(ViewsName.DocumentView, new[,] { { ViewsName.ParentId, obj.IDEntity.ToString() } }), Callback);
                ////    }
                ////}
                ////else
                ////{
                ////    // First level.
                ////    if (_root != null)
                ////    {
                ////        string addressView = QueryStringBuilder.Construct(ViewsName.CatalogView, new[,] { { ViewsName.ParentId, _root.IDEntity.ToString() } });
                ////        _regionManager.RequestNavigate(NameRegions.MainRegion, addressView, Callback);
                ////    }
                ////}
            }


            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            regionManager.RequestNavigate("TabRegion", ((PrismFourAuto.Staff.EntityBase)(obj1)).Title);
        }
    }
}
