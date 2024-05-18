using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class ViewModelFactory : IFactory
    {
        private readonly IViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly IViewModelFactory<AdminOptionsViewModel> _adminOptionsViewModelFactory;
        
        private readonly IViewModelFactory<ProductListingViewModel> _productListingViewModelFactory;
        private readonly IViewModelFactory<SupplierListingViewModel> _supplierListingViewModelFactory;
        private readonly IViewModelFactory<CategoryListingViewModel> _categoryListingViewModelFactory;
        
        private readonly IViewModelFactory<CreateCategoryViewModel> _createCategoryViewModelFactory;
        private readonly IViewModelFactory<CategoryViewModel> _categoryViewModelFactory;

        public ViewModelFactory(
            IViewModelFactory<LoginViewModel> loginViewModelFactory,
            IViewModelFactory<AdminOptionsViewModel> adminOptionsViewModelFactory,
            
            IViewModelFactory<ProductListingViewModel> productListingViewModelFactory,
            IViewModelFactory<SupplierListingViewModel> supplierListingViewModelFactory,
            IViewModelFactory<CategoryListingViewModel> categoryListingViewModelFactory,
            
            IViewModelFactory<CreateCategoryViewModel> createCategoryViewModelFactory,
            IViewModelFactory<CategoryViewModel> categoryViewModelFactory) 
        {
            _loginViewModelFactory = loginViewModelFactory;
            _adminOptionsViewModelFactory = adminOptionsViewModelFactory;
            
            _productListingViewModelFactory = productListingViewModelFactory;
            _supplierListingViewModelFactory = supplierListingViewModelFactory;
            _categoryListingViewModelFactory = categoryListingViewModelFactory;
            
            _createCategoryViewModelFactory = createCategoryViewModelFactory;
            _categoryViewModelFactory = categoryViewModelFactory;
        }

        public ViewModelBase Create(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.AdminOptions:
                    return _adminOptionsViewModelFactory.CreateViewModel();
                
                case ViewType.ProductListing:
                    return _productListingViewModelFactory.CreateViewModel();
                case ViewType.CategoryListing:
                    return _categoryListingViewModelFactory.CreateViewModel();
                case ViewType.SupplierListing:
                    return _supplierListingViewModelFactory.CreateViewModel();
                
                case ViewType.CreateCategory:
                    return _createCategoryViewModelFactory.CreateViewModel();
                case ViewType.ViewCategory:
                    return _categoryViewModelFactory.CreateViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
