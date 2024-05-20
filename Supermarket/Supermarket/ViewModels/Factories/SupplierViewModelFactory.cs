using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class SupplierViewModelFactory : IViewModelFactory<SupplierViewModel>
    {
        private readonly SupplierStore _supplierStore;
        private readonly SupplierService _supplierService;

        public SupplierViewModelFactory(SupplierStore supplierStore, SupplierService supplierService)
        {
            _supplierStore = supplierStore;
            _supplierService = supplierService;
        }
        public SupplierViewModel CreateViewModel()
        {
            return new SupplierViewModel(_supplierStore, _supplierService);
        }
    }
}
