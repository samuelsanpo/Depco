using System;
using System.ComponentModel;
using System.Windows.Input;
using Depco.Service;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace DepcoApp.ViewModel
{
    public class CameraViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private DialogService dialogService;
        private NavigationService navigationService;
        private string accionText;
        #endregion

        #region Properties
        public string AccionText
        {
            set
            {
                if (accionText != value)
                {
                    accionText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AccionText"));
                }
            }
            get
            {
                return accionText;
            }
        }
        #endregion

        #region Constructor
        public CameraViewModel()
        {
            //Singleton
            instance = this;
            //Services
            dialogService = new DialogService();
            navigationService = new NavigationService();
            //Text
            AccionText = "0 saltos";
        }
        #endregion

        #region Methods
        #endregion

        #region Singleton

        private static CameraViewModel instance;

        public static CameraViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new CameraViewModel();
            }

            return instance;
        }

        #endregion

        #region Commands
        public ICommand OpenCameraCommand { get { return new RelayCommand(OpenCamera); } }

        public ICommand RegisterCommand { get { return new RelayCommand(Register); } }

        private async void OpenCamera()
        {
            var isInitialize = await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.IsSupported || !isInitialize)
            {
                await dialogService.ShowMessage("Error", "No se pudo acceder a la camara");
                return;
            }

            var newPhotoID = Guid.NewGuid();

            using (var photo = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions()
            {
                Name = newPhotoID.ToString(),
                SaveToAlbum = true,
                DefaultCamera = CameraDevice.Rear,
                Directory = "Decap"
            }))
            {
                if (string.IsNullOrWhiteSpace(photo?.Path))
                {
                    return;
                }
            }

            AccionText = "3 saltos";
            await dialogService.ShowMessage("¡Bien!", "Realizaste 3 saltos");
            

        }

        private async void Register()
        {
            await dialogService.ShowMessage("¡Excelente!", "Se han registrado tus saltos correctamente");
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
