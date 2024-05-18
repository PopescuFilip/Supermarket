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
        private readonly NavigationService<ProductListingViewModel> _productListingNavigationService;
        private readonly NavigationService<SupplierListingViewModel> _supplierListingNavigationService;
        private readonly NavigationService<CategoryListingViewModel> _categoryListingNavigationService;
        public AdminOptionsViewModelFactory(
            NavigationService<ProductListingViewModel> productListingNavigationService,
            NavigationService<SupplierListingViewModel> supplierListingNavigationService,
            NavigationService<CategoryListingViewModel> categoryListingNavigationService) 
        {
            _productListingNavigationService = productListingNavigationService;
            _supplierListingNavigationService = supplierListingNavigationService;
            _categoryListingNavigationService = categoryListingNavigationService;
        }
        public AdminOptionsViewModel CreateViewModel()
        {
            return new AdminOptionsViewModel(
                _productListingNavigationService, 
                _supplierListingNavigationService, 
                _categoryListingNavigationService);
        }
    }
}
