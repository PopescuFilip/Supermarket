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
    public class ProductViewModelFactory : IViewModelFactory<ProductViewModel>
    {
        private readonly EntityStore<Product> _entityStore;
        private readonly IEntityService<Product> _entityService;

        public ProductViewModelFactory(EntityStore<Product> entityStore, IEntityService<Product> entityService) 
        {
            this._entityStore = entityStore;
            this._entityService = entityService;
        }
        public ProductViewModel CreateViewModel()
        {
            return new ProductViewModel(_entityStore, _entityService);
        }
    }
}
