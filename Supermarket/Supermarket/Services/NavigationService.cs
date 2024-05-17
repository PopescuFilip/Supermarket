using Supermarket.Stores;
using Supermarket.ViewModels;
using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Supermarket.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly IViewModelFactory<TViewModel> _factory;

        public NavigationService(NavigationStore navigationStore, IViewModelFactory<TViewModel> factory)
        {
            _navigationStore = navigationStore;
            _factory = factory;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _factory.CreateViewModel();
        }
    }
}