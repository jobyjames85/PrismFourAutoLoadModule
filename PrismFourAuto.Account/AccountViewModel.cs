using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.Common;
using PrismFourAuto.Data;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Account
{
    public class AccountViewModel : ViewModelBase, INavigationAware, IRegionMemberLifetime
    {
        #region Private Fields

        private readonly IEventAggregator _eventAggregator;
        private EntityBase _currentItem;
        private IManageStaff _manageStaff;

        /// <summary>
        /// The summary.
        /// </summary>
        private string changeValue;

        #endregion Private Fields

        #region Public Constructors

        public AccountViewModel(IManageStaff manageStaff, IEventAggregator eventAggregator)
        {
            _manageStaff = manageStaff;
            ChangeView = new DelegateCommand<object>(ChangeViewCommand);
            _eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<EventAggregationRaisEvent>().Subscribe(this.RaiseEventAggregationEvent, true);
            CurrentItem = new EntityBase();
            CurrentItem.Title = "AccountView";
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string ChangeValue
        {
            get
            {
                return this.changeValue;
            }

            set
            {
                this.changeValue = value;
                this.OnPropertyChanged("ChangeValue");
            }
        }

        public DelegateCommand<object> ChangeView { get; private set; }

        public EntityBase CurrentItem
        {
            get
            {
                return _currentItem;
            }
            private set
            {
                if (value != _currentItem)
                {
                    _currentItem = value;
                    this.OnPropertyChanged("CurrentItem");
                }
            }
        }

        #endregion Public Properties

        #region Public Methods

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            base.ConfirmNavigationRequest(navigationContext, continuationCallback);
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return base.IsNavigationTarget(navigationContext);
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            CurrentItem.Title = "AccountView";
        }

        #endregion Public Methods

        #region Private Methods

        private void ChangeViewCommand(object obj)
        {
            var unitycontainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unitycontainer.Resolve<IRegionManager>();
            Microsoft.Practices.Prism.Regions.IRegion rgn = regionManager.Regions["MainRegion"];
            //var navigationParameters = new NavigationParameters(); navigationParameters.Add("ID", 101);

            //var parameters = new NavigationParameters(); parameters.Add("ID", 101);
            //StringBuilder first = new StringBuilder();
            //first.Append("hello");
            //parameters.Add("myObjectParameter", new ObjectParameter("joby", first));
            Uri vu = new Uri("AccountDetailView", UriKind.Relative);
            rgn.RequestNavigate(vu , CheckForError);
        }

        private void CheckForError(NavigationResult nr)
        {
            if (nr.Result == false)
            {
                throw new Exception(nr.Error.Message);
            }
        }

        private void RaiseEventAggregationEvent(string obj)
        {
            ChangeValue = obj;
        }

        #endregion Private Methods
    }
}
