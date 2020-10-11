using System;
using System.ComponentModel;
using System.Windows.Input;
using Depco.Service;
using GalaSoft.MvvmLight.Command;

namespace Depco.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private NavigationService navigationService;
        private DialogService dialogService;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            //Singleton
            instance = this;
            //Services
            dialogService = new DialogService();
            navigationService = new NavigationService();

        }
        #endregion

        #region Methods
        #endregion

        #region Singleton

        private static LoginViewModel instance;

        public static LoginViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginViewModel();
            }

            return instance;
        }

        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

        private async void Login()
        {
            await navigationService.Navigate("Login");
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
