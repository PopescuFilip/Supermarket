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
        private readonly SupplierStore _supplierStore;
        private readonly SupplierService _supplierService;

        public SupplierListingViewModelFactory(SupplierStore supplierStore, SupplierService supplierService)
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
