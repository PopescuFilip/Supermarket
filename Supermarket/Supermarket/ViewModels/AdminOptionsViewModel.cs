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
        public ICommand SuppliersNavigationCommand { get; }
        public ICommand CategoriesNavigationCommand { get; }
        public AdminOptionsViewModel(
            NavigationService<ProductListingViewModel> productListingNavigationService,
            NavigationService<SupplierListingViewModel> supplierListingNavigationService,
            NavigationService<CategoryListingViewModel> categoryListingNavigationService) 
        {
            ProductsNavigationCommand = new NavigationCommand<ProductListingViewModel>(productListingNavigationService);
            SuppliersNavigationCommand = new NavigationCommand<SupplierListingViewModel>(supplierListingNavigationService);
            CategoriesNavigationCommand = new NavigationCommand<CategoryListingViewModel>(categoryListingNavigationService);
        }
    }
}
