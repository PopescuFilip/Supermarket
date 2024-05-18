﻿using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class ViewModelFactory : IFactory
    {
        IViewModelFactory<LoginViewModel> _loginViewModelFactory;
        IViewModelFactory<AdminOptionsViewModel> _adminOptionsViewModelFactory;
        IViewModelFactory<ProductListingViewModel> _productListingViewModelFactory;
        IViewModelFactory<SupplierListingViewModel> _supplierListingViewModelFactory;
        IViewModelFactory<CategoryListingViewModel> _categoryListingViewModelFactory;
        IViewModelFactory<CreateCategoryViewModel> _createCategoryViewModelFactory;
        public ViewModelFactory(
            IViewModelFactory<LoginViewModel> loginViewModelFactory,
            IViewModelFactory<AdminOptionsViewModel> adminOptionsViewModelFactory,
            IViewModelFactory<ProductListingViewModel> productListingViewModelFactory,
            IViewModelFactory<SupplierListingViewModel> supplierListingViewModelFactory,
            IViewModelFactory<CategoryListingViewModel> categoryListingViewModelFactory,
            IViewModelFactory<CreateCategoryViewModel> createCategoryViewModelFactory) 
        {
            _loginViewModelFactory = loginViewModelFactory;
            _adminOptionsViewModelFactory = adminOptionsViewModelFactory;
            _productListingViewModelFactory = productListingViewModelFactory;
            _supplierListingViewModelFactory = supplierListingViewModelFactory;
            _categoryListingViewModelFactory = categoryListingViewModelFactory;
            _createCategoryViewModelFactory = createCategoryViewModelFactory;
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
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
