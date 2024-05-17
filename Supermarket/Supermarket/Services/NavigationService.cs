using Supermarket.Stores;
using Supermarket.ViewModels;
using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public enum ViewType
    {
        Login,
        AdminOptions,
        CashierOptions
    }
    public class NavigationService
    {
        private readonly ViewModelFactory _factory;
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
        public NavigationService(ViewModelFactory factory) 
        {
            _factory = factory;
            Navigate(ViewType.Login);
        }
        public void Navigate(ViewType target)
        {
            CurrentViewModel = _factory.GetTargetViewModel(target);
        }
        private ViewModelBase GetTargetViewModel(ViewType target) 
        {
            switch (target)
            {
                case ViewType.Login:
                    //return new LoginViewModel(this);
                case ViewType.AdminOptions: 
                    throw new NotImplementedException();
                case ViewType.CashierOptions:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException("Invalid view type");
            }
        }

        public event Action? CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
