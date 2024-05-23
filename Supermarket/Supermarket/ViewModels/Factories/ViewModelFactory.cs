using Supermarket.Services;
using Supermarket.ViewModels;
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
        private readonly IViewModelFactory<StockListingViewModel> _stockListingViewModelFactory;
        private readonly IViewModelFactory<CreateProductViewModel> _createProductViewModelFactory;
        private readonly IViewModelFactory<ProductViewModel> _productViewModelFactory;
        private readonly IViewModelFactory<CreateCategoryViewModel> _createCategoryViewModelFactory;
        private readonly IViewModelFactory<CategoryViewModel> _categoryViewModelFactory;
        private readonly IViewModelFactory<CreateSupplierViewModel> _createSupplierViewModelFactory;
        private readonly IViewModelFactory<SupplierViewModel> _supplierViewModelFactory;
        private readonly IViewModelFactory<CreateStockViewModel> _createStockViewModelFactory;
        private readonly IViewModelFactory<StockViewModel> _stockViewModelFactory;
        private readonly IViewModelFactory<ProductsForSupplierViewModel> _productsForSupplierViewModelFactory;
        private readonly IViewModelFactory<ViewPricesForCategoryViewModel> _viewPricesForCategoryViewModelFactory;

        public ViewModelFactory(
            IViewModelFactory<LoginViewModel> loginViewModelFactory,
            IViewModelFactory<AdminOptionsViewModel> adminOptionsViewModelFactory,
            
            IViewModelFactory<ProductListingViewModel> productListingViewModelFactory,
            IViewModelFactory<SupplierListingViewModel> supplierListingViewModelFactory,
            IViewModelFactory<CategoryListingViewModel> categoryListingViewModelFactory,
            IViewModelFactory<StockListingViewModel> stockListingViewModelFactory,

            IViewModelFactory<CreateProductViewModel> createProductViewModelFactory,
            IViewModelFactory<ProductViewModel> productViewModelFactory,

            IViewModelFactory<CreateCategoryViewModel> createCategoryViewModelFactory,
            IViewModelFactory<CategoryViewModel> categoryViewModelFactory,

            IViewModelFactory<CreateSupplierViewModel> createSupplierViewModelFactory,
            IViewModelFactory<SupplierViewModel> supplierViewModelFactory,
            
            IViewModelFactory<CreateStockViewModel> createStockViewModelFactory,
            IViewModelFactory<StockViewModel> stockViewModelFactory,

            IViewModelFactory<ProductsForSupplierViewModel> productsForSupplierViewModelFactory, 
            IViewModelFactory<ViewPricesForCategoryViewModel> viewPricesForCategoryViewModelFactory) 
        {
            _loginViewModelFactory = loginViewModelFactory;
            _adminOptionsViewModelFactory = adminOptionsViewModelFactory;
            
            _productListingViewModelFactory = productListingViewModelFactory;
            _supplierListingViewModelFactory = supplierListingViewModelFactory;
            _categoryListingViewModelFactory = categoryListingViewModelFactory;
            _stockListingViewModelFactory = stockListingViewModelFactory;
            _createProductViewModelFactory = createProductViewModelFactory;
            _productViewModelFactory = productViewModelFactory;
            
            _createCategoryViewModelFactory = createCategoryViewModelFactory;
            _categoryViewModelFactory = categoryViewModelFactory;
            
            _createSupplierViewModelFactory = createSupplierViewModelFactory;
            _supplierViewModelFactory = supplierViewModelFactory;
            _createStockViewModelFactory = createStockViewModelFactory;
            _stockViewModelFactory = stockViewModelFactory;
            
            _productsForSupplierViewModelFactory = productsForSupplierViewModelFactory;
            _viewPricesForCategoryViewModelFactory = viewPricesForCategoryViewModelFactory;
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
                case ViewType.StockListing:
                    return _stockListingViewModelFactory.CreateViewModel();

                case ViewType.CreateProduct:
                    return _createProductViewModelFactory.CreateViewModel();
                case ViewType.ViewProduct:
                    return _productViewModelFactory.CreateViewModel();

                case ViewType.CreateCategory:
                    return _createCategoryViewModelFactory.CreateViewModel();
                case ViewType.ViewCategory:
                    return _categoryViewModelFactory.CreateViewModel();
                
                case ViewType.CreateSupplier:
                    return _createSupplierViewModelFactory.CreateViewModel();
                case ViewType.ViewSupplier:
                    return _supplierViewModelFactory.CreateViewModel();

                case ViewType.CreateStock:
                    return _createStockViewModelFactory.CreateViewModel();
                case ViewType.ViewStock:
                    return _stockViewModelFactory.CreateViewModel();

                case ViewType.ViewProductsForSupplier:
                    return _productsForSupplierViewModelFactory.CreateViewModel();
                case ViewType.ViewPriceForCategory:
                    return _viewPricesForCategoryViewModelFactory.CreateViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
