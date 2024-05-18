using Supermarket.Commands;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class AdminOptionsViewModel : ViewModelBase
    {
        public ICommand ProductsNavigationCommand { get; }
        public AdminOptionsViewModel(NavigationService<ProductListingViewModel> productsListingNavigationService) 
        {
            ProductsNavigationCommand = new NavigationCommand<ProductListingViewModel>(productsListingNavigationService);
        }
    }
}
