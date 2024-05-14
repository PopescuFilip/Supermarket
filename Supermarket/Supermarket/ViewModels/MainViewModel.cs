using Supermarket.DB;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Supermarket.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SupermarketDBContextFactory _dBContextFactory;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore, SupermarketDBContextFactory dBContextFactory)
        {
            _navigationStore = navigationStore;
            _dBContextFactory = dBContextFactory;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
