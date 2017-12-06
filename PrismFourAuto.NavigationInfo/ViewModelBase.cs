using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace PrismFourAuto.NavigationInfo
{
    public abstract class ViewModelBase : IRegionMemberLifetime, INotifyPropertyChanged, IConfirmNavigationRequest, INavigationAware
    {
        #region Public Fields

        public static IRegionNavigationJournal _navigationJournal;

        #endregion Public Fields

        #region Private Fields

        private string _currentItem;

        //public DelegateCommand<object> GoBackCommand { get; private set; }
        //public ICommand ForCommand { get; private set; }
        //public DelegateCommand<object> GoForwardCommand { get; private set; }
        private bool _keepAliveState = true;

        private DelegateCommand<object> _killingCommand;
        private String _originalTargetUriString;
        private IRegionManager _regionManager;
        private IRegionNavigationService navigationService;

        #endregion Private Fields

        #region Public Constructors

        public ViewModelBase()
        {
            navigationService = ServiceLocator.Current.GetInstance<IRegionNavigationService>();
            //GoBackCommand = new DelegateCommand<object>(GoBack, CanGoBack);
            //GoForwardCommand = new DelegateCommand<object>(GoForward, CanGoForward);
        }

        #endregion Public Constructors

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Public Properties

        public String CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                _currentItem = value;
                this.OnPropertyChanged("CurrentItem");
            }
        }

        public ICommand JournalBackCommand { get { return new DelegateCommand(JournalBackExecute, CanJournalBackExecute); } }

        public ICommand JournalForwardCommand { get { return new DelegateCommand(JournalForwardExecute, CanJournalForwardExecute); } }

        public bool KeepAlive
        {
            get { return _keepAliveState; }
        }

        public virtual DelegateCommand<object> KillingCommand
        {
            get { return _killingCommand ?? (_killingCommand = new DelegateCommand<object>(KillView)); }
            set { _killingCommand = value; }
        }

        #endregion Public Properties

        #region Public Methods

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            String item = null;

            if (navigationContext.Parameters != null)
            {
                item = navigationContext.Parameters["Id"];
            }

            Boolean result = this.CurrentItem == item;

            return result;
        }

        public void JournalBackExecute()
        {
            if (_navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }

        public void JournalForwardExecute()
        {
            if (_navigationJournal.CanGoForward)
            {
                _navigationJournal.GoForward();
            }
        }

        public virtual void KillView(object view)
        {
            // Arbitrary Container.
            IRegionManager manager = ServiceLocator.Current.GetInstance<IRegionManager>();
            // find and remove view.
            foreach (IRegion region in manager.Regions)
            {
                // Find current view
                object removeView = region.Views.SingleOrDefault(v => v == view);
                if (removeView != null)
                    // Remove finding view.
                    manager.Regions[region.Name].Remove(view);
            }
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationService = navigationContext.NavigationService;
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationService == null)
            {
                if (((navigationContext.NavigationService).Region).Name == "MainRegion")
                {
                    navigationService = navigationContext.NavigationService;
                }
            }

            if (_navigationJournal == null)
            {
                if (((navigationContext.NavigationService).Region).Name == "MainRegion")
                {
                    _navigationJournal = navigationContext.NavigationService.Journal;
                }
            }

            if (_originalTargetUriString == null)
            {
                _originalTargetUriString = navigationContext.Uri.ToString();
            }

            //if (_navigationJournal == null)
            //{
            //    _navigationJournal = navigationContext.NavigationService.Journal;
            //}
            //if (_originalTargetUriString == null)
            //{
            //    _originalTargetUriString = navigationContext.Uri.ToString();
            //}

            //if (navigationContext.Parameters != null && this.CurrentItem == null)
            //{
            //    this.CurrentItem = navigationContext.Parameters["ID"];
            //}

            //navigationService = navigationContext.NavigationService;
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void Callback(NavigationResult result)
        {
        }

        private bool CanGoBack(object commandArg)
        {
            return true;
            //if (navigationService != null)
            //{
            //    return navigationService.Journal.CanGoBack;
            //}
            //else
            //{
            //    return false;
            //}
        }

        //private bool CanGoBack(object commandArg)
        //{
        //    return true;//;navigationService.Journal.CanGoBack;
        //}

        private bool CanGoForward(object commandArg)
        {
            return true;
            //if (navigationService != null)
            //{
            //    return navigationService.Journal.CanGoForward;
            //}
            //else
            //{
            //    return false;
            //}
        }

        private bool CanJournalBackExecute()
        {
            if (_navigationJournal != null)
            {
                return _navigationJournal.CanGoBack;
            }
            else
            {
                return true;
            }
        }

        private bool CanJournalForwardExecute()
        {
            if (_navigationJournal != null)
            {
                return _navigationJournal.CanGoForward;
            }
            else
            {
                return true;
            }
        }

        private void GoBack(object commandArg)
        {
            if (navigationService.Journal.CanGoBack)
            {
                navigationService.Journal.GoBack();
            }
        }

        //private void GoBack(object commandArg)
        //{
        //    if (navigationService.Journal.CanGoBack)
        //    {
        //        navigationService.Journal.GoBack();
        //    }
        //}

        private void GoForward(object commandArg)
        {
            if (navigationService.Journal.CanGoForward)
            {
                navigationService.Journal.GoForward();
            }
        }

        private void LoadDataFromRepositoryHandleExceptionCorrectly()
        {
            //simulate a call to the repository
            try
            {
                throw new Exception("Constants.Global.RepositoryExceptionMessage");
            }
            catch (Exception)
            {
                //PLEASE NEVER call MessageBox from a ViewModel.
                //This was done here to keep the code simple and about
                //navigation and not View/ViewModel UI interactiions.
                MessageBox.Show("Constants.Global.HandledExceptionMessage, Constants.Global.Exception, MessageBoxButton.OK, MessageBoxImage.Error");

                //NOTE: keep alive to false so that this View/ViewModel will be removed
                _keepAliveState = false;

                _navigationJournal.GoBack();
            }
        }

        #endregion Private Methods

        //private ErrorsContainer<ValidationResult> errorsContainer = new ErrorsContainer<ValidationResult>(pn => RaiseErrorsChanged(pn));

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}
        //protected void RaiseErrorsChanged( string propertyName )
        //{
        // var handler = this.ErrorsChanged; if (handler != null) { handler(this, new DataErrorsChangedEventArgs(propertyName) ); } }
        //public bool HasErrors
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public string Error
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public string this[string columnName]
        //{
        //    get { throw new NotImplementedException(); }
        //}
    }
}

//public virtual void OnNavigatedTo(NavigationContext navigationContext)
//{
//    if (_navigationJournal == null)
//    {
//        _navigationJournal = navigationContext.NavigationService.Journal;
//    }
//    if (_originalTargetUriString == null)
//    {
//        _originalTargetUriString = navigationContext.Uri.ToString();
//    }
//}
//&& navigationContext.Parameters["Constants.Global.Item] == Constants.Global.Throw"

//if (navigationContext.Parameters != null)
//{
//    throw new Exception("Constants.Global.ExceptionThrownAfterNavigationCompleted");
//}

//This simulates calling into a repository to get the required data.
//While getting the data the repository throws.
//In this example we will handle the exception correctly rather than
//allow a local exception to be bubbled up to the navigation API.
//
//Takaway:  Non navigation related exceptions should be handled by the View/ViewModel and not the navigation API.
// && navigationContext.Parameters["Constants.Global.Item] == Constants.Global.ThrowAndHandle
//if (navigationContext.Parameters != null)
//{
//    this.LoadDataFromRepositoryHandleExceptionCorrectly();
//}

//only set the current item on the initial navigation.
//if (navigationContext.Parameters != null && this.CurrentItem == null)
//{
//    this.CurrentItem = navigationContext.Parameters["Constants.Global.Item"];
//}
//}