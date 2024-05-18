using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class AdminOptionsViewModelFactory : IViewModelFactory<AdminOptionsViewModel>
    {
        private readonly NavigationService<ProductListingViewModel> _productsListingNavigationService;
        public AdminOptionsViewModelFactory(NavigationService<ProductListingViewModel> productsListingNavigationService) 
        {
            _productsListingNavigationService = productsListingNavigationService;
        }
        public AdminOptionsViewModel CreateViewModel()
        {
            return new AdminOptionsViewModel(_productsListingNavigationService);
        }
    }
}
