using System;
using System.Threading.Tasks;
using Depco.View;
using Depco.ViewModel;
using Depco_App;
using DepcoApp.ViewModel;
using Xamarin.Forms;

namespace Depco.Service
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            var mainViewModel = MainViewModel.GetInstance();
            switch (pageName)
            {
                case "Login":
                    mainViewModel.camera = new CameraViewModel();
                    Application.Current.MainPage = new PaginaPrincipal();
                    break;
                default:
                    break;
            }
        }

        public async Task Back()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
