using Supermarket.Services;
using Supermarket.ViewModels;
using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Stores
{
    public class NavigationStore
    {
        private readonly NavigationService _navigation;
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public NavigationStore(NavigationService navigation)
        {
            _navigation = navigation;
            CurrentViewModel = _navigation.CurrentViewModel;
            //_navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        public event Action? CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}