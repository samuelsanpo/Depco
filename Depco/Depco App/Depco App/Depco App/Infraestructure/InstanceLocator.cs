using System;
using Depco.ViewModel;

namespace Depco.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            var mainViewModel = MainViewModel.GetInstance();
            Main = mainViewModel;
        }
    }
}
