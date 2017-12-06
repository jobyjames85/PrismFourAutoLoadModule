using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace PrismFourAuto.Account
{
    public class NavigationAccountModuleViewModel : PrismFourAuto.NavigationInfo.ViewModelBase
    {
        IRegionManager _regionManager;
        public DelegateCommand<object> SelectedCommand { get; private set; }
        public NavigationAccountModuleViewModel()
        {
            SelectedCommand = new DelegateCommand<object>(SelectedExecute, CanExecuteSelected);
            _categories = new ObservableCollection<EntityBase>();
            Categories.Add(new EntityBase() { Title = "AccountDetailView", });
            Categories.Add(new EntityBase() { Title = "AccountView" });
            Categories.Add(new EntityBase() { Title = "Test3" });
        }

        public EntityBase CurrentCategory { get; private set; }

        private ObservableCollection<EntityBase> _categories;
        public ObservableCollection<EntityBase> Categories { get { return _categories; } }

        private EntityBase _root;
        public EntityBase Root // Populate in NavigationDocumentsViewModel_PropertyChanged
        {
            get { return _root ?? new Catalog() { Title = "Account" }; }
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

        private void SelectedExecute(object obj)
        {
            if (obj == null)
            {
                return;
            }

            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            regionManager.RequestNavigate("TabRegion", ((PrismFourAuto.Account.EntityBase)(obj)).Title);
        }
    }
}
