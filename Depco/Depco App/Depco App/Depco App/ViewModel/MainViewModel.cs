using System;
using Depco.Service;

namespace Depco.ViewModel
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService;
        private DialogService dialogService;
        #endregion

        #region Properties
        public LoginViewModel login { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            //Services
            dialogService = new DialogService();
            navigationService = new NavigationService();
            //ViewModel
            login = new LoginViewModel();
        }
        #endregion

        #region Methods
        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Commands
        #endregion

        #region Events
        #endregion
    }
}
