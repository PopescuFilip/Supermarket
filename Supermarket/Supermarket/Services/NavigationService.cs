using Supermarket.Stores;
using Supermarket.ViewModels;
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
        private readonly NavigationStore _navigationStore;
        public NavigationService(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
        }
        public void Navigate(ViewType target)
        {
            _navigationStore.CurrentViewModel = GetTargetViewModel(target);
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
    }
}
