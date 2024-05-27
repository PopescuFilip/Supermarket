using Supermarket.Models;
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
        private readonly EntityStore<Supplier> _supplierStore;
        private readonly IEntityService<Supplier> _supplierService;
        private readonly IEntityService<Product> _productService;

        public SupplierViewModelFactory(
            EntityStore<Supplier> supplierStore,
            IEntityService<Supplier> supplierService,
            IEntityService<Product> productService)
        {
            _supplierStore = supplierStore;
            _supplierService = supplierService;
            _productService = productService;
        }
        public SupplierViewModel CreateViewModel()
        {
            return new SupplierViewModel(_supplierStore, _supplierService, _productService);
        }
    }
}
