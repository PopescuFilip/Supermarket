﻿using Supermarket.Services;
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
        private readonly IViewModelFactory<CashierOptionsViewModel> _cashierOptionsViewModelFactory;
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
        private readonly IViewModelFactory<SearchProductViewModel> _searchProductViewModelFactory;
        private readonly IViewModelFactory<AddReceiptViewModel> _addReceiptViewModelFactory;
        private readonly IViewModelFactory<AddReceiptItemViewModel> _addReceiptItemViewModelFactory;
        private readonly IViewModelFactory<BuyableStockListingViewModel> _buyableStockViewModelFactory;

        public ViewModelFactory(
            IViewModelFactory<LoginViewModel> loginViewModelFactory,
            IViewModelFactory<AdminOptionsViewModel> adminOptionsViewModelFactory,
            IViewModelFactory<CashierOptionsViewModel> cashierOptionsViewModelFactory,
            
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
            IViewModelFactory<ViewPricesForCategoryViewModel> viewPricesForCategoryViewModelFactory,
            
            IViewModelFactory<SearchProductViewModel> searchProductViewModelFactory, 
            IViewModelFactory<AddReceiptViewModel> addReceiptViewModelFactory,
            IViewModelFactory<AddReceiptItemViewModel> addReceiptItemViewModelFactory,
            IViewModelFactory<BuyableStockListingViewModel> buyableStockViewModelFactory) 
        {
            _loginViewModelFactory = loginViewModelFactory;
            _adminOptionsViewModelFactory = adminOptionsViewModelFactory;
            _cashierOptionsViewModelFactory = cashierOptionsViewModelFactory;
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
            
            _searchProductViewModelFactory = searchProductViewModelFactory;
            _addReceiptViewModelFactory = addReceiptViewModelFactory;
            _addReceiptItemViewModelFactory = addReceiptItemViewModelFactory;
            _buyableStockViewModelFactory = buyableStockViewModelFactory;
        }

        public ViewModelBase Create(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.AdminOptions:
                    return _adminOptionsViewModelFactory.CreateViewModel();
                case ViewType.CashierOptions:
                    return _cashierOptionsViewModelFactory.CreateViewModel();
                
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

                case ViewType.SearchProduct:
                    return _searchProductViewModelFactory.CreateViewModel();
                case ViewType.AddReceipt:
                    return _addReceiptViewModelFactory.CreateViewModel();
                case ViewType.AddReceiptItem:
                    return _addReceiptItemViewModelFactory.CreateViewModel();
                case ViewType.BuyableStockListing:
                    return _buyableStockViewModelFactory.CreateViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
