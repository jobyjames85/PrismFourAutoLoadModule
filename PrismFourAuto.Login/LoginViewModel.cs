using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PrismFourAuto.Data;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Login
{
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// The summary.
        /// </summary>
        private string userName;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
                this.OnPropertyChanged("UserName");
            }
        }

        /// <summary>
        /// The summary.
        /// </summary>
        private string password;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                this.OnPropertyChanged("Password");
            }
        }

        private IManageStaff _managerStaff;
        public ICommand LoginCommand { get; private set; }

        public LoginViewModel(IManageStaff managerStaff)
        {
            _managerStaff = managerStaff;
            LoginCommand = new DelegateCommand(SubmitLoginDetails);
        }

        private void SubmitLoginDetails()
        {
            var check = _managerStaff.GetStaffs().Where(x => x.Username == UserName && x.Password == Password).Any();
            if (check)
            {
                IUnityContainer unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
                var regionManager = unityContainer.Resolve<IRegionManager>();
                Microsoft.Practices.Prism.Regions.IRegion rgn = regionManager.Regions["MainRegion"];
                rgn.Context = Guid.NewGuid();
               // var navigationParameters = new NavigationParameters(); navigationParameters.Add(UserName, Password);
                //regionManager.Regions["MainRegion"].RequestNavigate("MainFrameNavigate" + navigationParameters, CheckNavigation);
                regionManager.Regions["MainRegion"].RequestNavigate("MainFrameNavigate", CheckNavigation);
            }
        }

        private void CheckNavigation(NavigationResult nr)
        {
            if (nr.Result == false)
            {
                throw new Exception(nr.Error.Message);
            }
        }
    }
}
