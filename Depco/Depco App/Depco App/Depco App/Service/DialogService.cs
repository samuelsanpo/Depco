using System;
using System.Threading.Tasks;
using Depco_App;

namespace Depco.Service
{
    public class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Entendido");
        }

        public async Task<bool> ShowConfirm(string title, string message)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, "Si", "No");
        }
    }
}
