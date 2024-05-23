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
    public class ProductsForSupplierViewModelFactory : IViewModelFactory<ProductsForSupplierViewModel>
    {
        private readonly EntityStore<Supplier> _entityStore;
        private readonly IEntityService<Product> _entityService;

        public ProductsForSupplierViewModelFactory(
            EntityStore<Supplier> entityStore, 
            IEntityService<Product> entityService)
        {
            _entityStore = entityStore;
            _entityService = entityService;
        }
        public ProductsForSupplierViewModel CreateViewModel()
        {
            return new ProductsForSupplierViewModel(_entityStore, _entityService);
        }
    }
}
