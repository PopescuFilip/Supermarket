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
    public class ProductsListingViewModelFactory : IViewModelFactory<ProductListingViewModel>
    {
        private readonly EntityStore<Product> _entityStore;
        private readonly IEntityService<Product> _entityService;

        public ProductsListingViewModelFactory(EntityStore<Product> entityStore, IEntityService<Product> entityService) 
        {
            _entityStore = entityStore;
            _entityService = entityService;
        }
        public ProductListingViewModel CreateViewModel()
        {
            return new ProductListingViewModel(_entityStore, _entityService);
        }
    }
}
