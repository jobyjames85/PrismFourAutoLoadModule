using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Regions;
using PrismFourAuto.Common;
using PrismFourAuto.Data;
using PrismFourAuto.NavigationInfo;

namespace PrismFourAuto.Account
{
    public class AccountDetailViewModel : ViewModelBase, INavigationAware
    {
        #region Private Fields

        private IManageStaff _manageStaff;

        #endregion Private Fields

        #region Public Constructors

        public AccountDetailViewModel(IManageStaff manageStaff)
        {
            _manageStaff = manageStaff;
        }

        #endregion Public Constructors

        #region Public Methods

        public override void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            base.ConfirmNavigationRequest(navigationContext, continuationCallback);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }

        #endregion Public Methods
    }
}