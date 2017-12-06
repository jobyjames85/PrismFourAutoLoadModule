using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.Data;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Staff
{
    public class StaffDetailsViewModel : ViewModelBase, IActiveAware, INavigationAware, IRegionMemberLifetime
    {
        #region Private Fields

        private readonly AllCommandProxy _CommandProxy;
        private bool _IsActive = false;
        private IManageStaff _manageStaff;

        private IRegionNavigationService navigationService;

        /// <summary>
        /// The summary.
        /// </summary>
        private ObservableCollection<PrismFourAuto.Model.Models.Staff> staffList;

        /// <summary>
        /// The summary.
        /// </summary>
        private string thumbnailPath;

        #endregion Private Fields

        #region Public Constructors
        private readonly EventHandler eventHandler;
        public StaffDetailsViewModel(IManageStaff managerStaff, AllCommandProxy commandProxy)
        {
            _manageStaff = managerStaff;
            ChangeView = new DelegateCommand(LodeViewfromModule);
            LoadChild = new DelegateCommand(LoadChildCommand);
            ThumbnailPath = "WIN_20150804_135055.JPG";
            StaffList = new ObservableCollection<Model.Models.Staff>(_manageStaff.GetStaffsTest());
            _CommandProxy = commandProxy;
            _CommandProxy.FireCompositeCommand.RegisterCommand(LoadChild);

            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            Microsoft.Practices.Prism.Regions.IRegion rgn = regionManager.Regions["MainRegion"];
            rgn.Context = Guid.NewGuid(); ;
           

        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler IsActiveChanged;

        #endregion Public Events

        #region Public Properties

        public ICommand ChangeView { get; private set; }

       

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
                if (value)
                    OnActivate();
                else
                    OnDeactivate();
            }
        }

        public bool KeepAlive
        {
            get { return false; }
        }

        public ICommand LoadChild { get; private set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public ObservableCollection<PrismFourAuto.Model.Models.Staff> StaffList
        {
            get
            {
                return this.staffList;
            }

            set
            {
                this.staffList = value;
                this.OnPropertyChanged("StaffList");
            }
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string ThumbnailPath
        {
            get
            {
                return this.thumbnailPath;
            }

            set
            {
                this.thumbnailPath = value;
                this.OnPropertyChanged("ThumbnailPath");
            }
        }

        #endregion Public Properties

        #region Public Methods

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return base.IsNavigationTarget(navigationContext);
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            if (navigationContext.Parameters != null && navigationContext.Parameters.Count() > 0)
            {
                string id = navigationContext.Parameters["ID"].ToString();
                var myParameter = navigationContext.Parameters["myObjectParameter"];
            }
            base.OnNavigatedTo(navigationContext);
            navigationService = navigationContext.NavigationService;
        }

        #endregion Public Methods

        #region Private Methods

        private bool CanGoBack(object commandArg)
        {
            return navigationService.Journal.CanGoBack;
        }

        private void GoBack(object commandArg)
        {
            if (navigationService.Journal.CanGoBack)
            {
                navigationService.Journal.GoBack();
            }
        }

        private void LoadChildCommand()
        {
            Window obj = new Window();
            obj.Show();
        }

        private void LodeViewfromModule()
        {
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            var uri = new Uri("pack://application:,,,/PrismAuto.Account;component/AccountView.xaml", UriKind.RelativeOrAbsolute);
            regionManager.RequestNavigate("MainRegion", "AccountView");

            ////Working Code
            ////var unitycontainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            ////var regionManager = unitycontainer.Resolve<IRegionManager>();
            ////var uri = new Uri("StaffDetailsView", UriKind.Relative);
            ////regionManager.RequestNavigate("MainRegion", uri);

            ////Working Code
            ////var resolvetype = unitycontainer.Resolve<StaffDetailsView>();
            ////regionManager.RegisterViewWithRegion("MainRegion", () => resolvetype);
            ////var region = this.regionManager.Regions["MainRegion"];
            ////region.Activate(resolvetype);

            //Working Code
            ////var region = this.regionManager.Regions["MainRegion"];
            ////StaffDetailsView view = unityContainer.Resolve<StaffDetailsView>();
            ////region.Add(resolvetype);
            //// region.Activate(resolvetype);
        }

        private void OnActivate()
        {
        }

        private void OnDeactivate()
        {
        }

        #endregion Private Methods
    }
}
