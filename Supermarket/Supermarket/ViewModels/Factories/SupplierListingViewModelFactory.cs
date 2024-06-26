﻿using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class SupplierListingViewModelFactory : IViewModelFactory<SupplierListingViewModel>
    {
        private readonly EntityStore<Supplier> _supplierStore;
        private readonly IEntityService<Supplier> _supplierService;

        public SupplierListingViewModelFactory(EntityStore<Supplier> supplierStore, IEntityService<Supplier> supplierService)
        {
            _supplierStore = supplierStore;
            _supplierService = supplierService;
        }
        public SupplierListingViewModel CreateViewModel()
        {
            return new SupplierListingViewModel(_supplierStore, _supplierService);
        }
    }
}
