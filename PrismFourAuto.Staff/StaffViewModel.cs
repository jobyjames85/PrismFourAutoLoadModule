using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.Common;
using PrismFourAuto.Data;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Staff
{
    public class StaffViewModel : ViewModelBase, IRegionMemberLifetime, INavigationAware
    {
        private IManageStaff _manageStaff;
        private readonly IRegionManager regionManager;

        // private readonly IUnityContainer container;
        private IRegionNavigationService navigationService;
        private readonly InteractionRequest<Confirmation> confirmExitInteractionRequest;

        public IInteractionRequest ConfirmExitInteractionRequest
        {
            get { return this.confirmExitInteractionRequest; }
        }

        public ICommand SubmitCommand { get; private set; }

        public ICommand LoadWindow { get; private set; }

        public ICommand StudentCommand { get; private set; }

        public bool KeepAlive
        {
            get { return true; }
        }

        public DelegateCommand<object> LoadAccountCommand { get; private set; }



        private void GoBack(object commandArg)
        {
            if (navigationService.Journal.CanGoBack)
            {
                navigationService.Journal.GoBack();
            }
        }

        private bool CanGoBack(object commandArg)
        {
            return navigationService.Journal.CanGoBack;
        }




        private readonly AllCommandProxy _CommandProxy;

        private readonly IEventAggregator _eventAggregator;

        public ICommand AsyncCommand { get; private set; }

        public ICommand ButtonClickCommand { get; private set; }

        public StaffViewModel(IManageStaff manageStaff, IEventAggregator eventAggregator, AllCommandProxy commandProxy)
        {
            regionManager = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<Microsoft.Practices.Prism.Regions.IRegionManager>();
            _manageStaff = manageStaff;
            SubmitCommand = new DelegateCommand<object>(OnSubmit);
            LoadWindow = new DelegateCommand(LoadWindowCommand);
            this.confirmExitInteractionRequest = new InteractionRequest<Confirmation>();
            _eventAggregator = eventAggregator;
            LoadAccountCommand = new DelegateCommand<object>(LoadAccount);
            _CommandProxy = commandProxy;
            _CommandProxy.FireCompositeCommand.RegisterCommand(LoadWindow);
            StartProgress = new DelegateCommand(StartProgressComand);
            StudentCommand = new DelegateCommand(GetStudent);
            AsyncCommand = new DelegateCommand(AsyncCall);
            //add RoutedEventArgs remove TriggerParameterPath
            ButtonClickCommand = new DelegateCommand<RoutedEvent>(ClickCommand);
            ////var staffobj = RegionManager.Regions["MainRegion"].Context;
            ////int staffIdId = (int)RegionContext.GetObservableContext(StaffView).Value;
            ////RegionManager.Regions["MainRegion"].Context = regionManager.Regions["MainRegion"].Context;
        }

        //add Parameter RoutedEventArgs
        private void ClickCommand(RoutedEvent obj)
        {
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            regionManager.RequestNavigate("MainRegion", "InteractionRequestView");
        }
        public delegate string AsyncMethodCaller(int callDuration, out int threadId);

        //Delegate out
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }

        //Function
        public string TestMethod(int callDuration, int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }

        private void AsyncCall()
        {
            int threadId = 0;

            AsyncMethodCaller caller = new AsyncMethodCaller(TestMethod);

            IAsyncResult result = caller.BeginInvoke(3000, out threadId, null, null);

            Thread.Sleep(0);

            AsyncResultTest = string.Format("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            AsyncResultTest = caller.EndInvoke(out threadId, result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            AsyncResultTest = string.Format("The call executed on thread {0}, with return value \"{1}\".", threadId, AsyncResultTest);

            Func<int, int, string> objfunction = TestMethod;

            IAsyncResult result1 = objfunction.BeginInvoke(4000, threadId, null, null);

            Thread.Sleep(0);

            AsyncResultTest = string.Format("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);

            // Wait for the WaitHandle to become signaled.
            result1.AsyncWaitHandle.WaitOne();

            // Close the wait handle.
            result1.AsyncWaitHandle.Close();

            AsyncResultTest = string.Format("The call executed on thread {0}, with return value \"{1}\".", threadId, result1);
        }

        /// <summary>
        /// The summary.
        /// </summary>
        private string asyncResultTest;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string AsyncResultTest
        {
            get
            {
                return this.asyncResultTest;
            }

            set
            {
                this.asyncResultTest = value;
                this.OnPropertyChanged("AsyncResultTest");
            }
        }

        public int Add(int a, int b)
        {
            Console.WriteLine("Add() running on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);
            return (a + b);
        }

        private void AddComplete(IAsyncResult ar)
        {
            Console.WriteLine("AddComplete() running on thread {0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Operation completed.");
        }

        private void GetStudent()
        {
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            regionManager.RequestNavigate("MainRegion", "StudentView");
        }

        private void StartProgressComand()
        {
            //ProgressAsyncWork progress = new ProgressAsyncWork();
            //progress.ProgressReporter = new Progress<int>(ProgressReportMethod);
            //System.Threading.Thread.Sleep(200);
            // progress.StartAsync();
        }

        private void ProgressReportMethod(int value)
        {
            this.ProgressValue = value;
        }

        private void LoadWindowCommand()
        {
            Window obj = new Window();
            obj.Show();
        }

        private void LoadAccount(object obj)
        {
            IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unityContainer.Resolve<IRegionManager>();
            regionManager.RequestNavigate("SideRegion", "AccountSelectView");
        }

        /// <summary>
        /// The summary.
        /// </summary>
        private int progressValue;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public int ProgressValue
        {
            get
            {
                return this.progressValue;
            }

            set
            {
                this.progressValue = value;
                this.OnPropertyChanged("ProgressValue");
            }
        }

        public ICommand StartProgress { get; private set; }

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            ////Showing Confirm message box before going to Navigate the screen , issue in back button (double back then only go back)
            this.confirmExitInteractionRequest.Raise(new Confirmation { Content = "Hello Navigate...", Title = "Test Navigate..." }, c => { continuationCallback(c.Confirmed); });
            //base.ConfirmNavigationRequest(navigationContext, continuationCallback);
        }

        Boolean _confirmNavigation;
        public Boolean ConfirmNavigation
        {
            get { return _confirmNavigation; }
            set
            {
                _confirmNavigation = value;
                this.OnPropertyChanged("ConfirmNavigation");
            }
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
        }

        private void OnSubmit(object value)
        {
            this._eventAggregator.GetEvent<EventAggregationRaisEvent>().Publish("Tested forst Aggregation event");

            var unitycontainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = unitycontainer.Resolve<IRegionManager>();
            Microsoft.Practices.Prism.Regions.IRegion rgn = regionManager.Regions["MainRegion"];
            //var navigationParameters = new NavigationParameters(); navigationParameters.Add("ID", 101);

            //var parameters = new NavigationParameters(); parameters.Add("ID", 101);
            //StringBuilder first = new StringBuilder();
            //first.Append("hello");
            //parameters.Add("myObjectParameter", new ObjectParameter("joby", first));
            ////Uri vu = new Uri("StaffDetailsView", UriKind.Relative);
            rgn.RequestNavigate("StaffDetailsView" , CheckForError);

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

            ////Working Code
            ////var region = this.regionManager.Regions["MainRegion"];
            ////StaffDetailsView view = unitycontainer.Resolve<StaffDetailsView>();
            ////region.Add(resolvetype);
            //// region.Activate(resolvetype);
        }

        private void CheckForError(NavigationResult nr)
        {
            if (nr.Result == false)
            {
                //throw new Exception(nr.Error.Message);
            }
        }

        internal void SetGuid(Guid myGuid)
        {
            MessageBox.Show(myGuid + "Changed");
        }
    }
}
