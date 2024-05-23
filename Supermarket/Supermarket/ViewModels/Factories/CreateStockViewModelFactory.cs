using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CreateStockViewModelFactory : IViewModelFactory<CreateStockViewModel>
    {
        private readonly IEntityService<Stock> _entityService;
        private readonly IEntityService<Product> _productService;

        public CreateStockViewModelFactory(
            IEntityService<Stock> entityService,
            IEntityService<Product> productService)
        {
            _entityService = entityService;
            _productService = productService;
        }
        public CreateStockViewModel CreateViewModel()
        {
            return new CreateStockViewModel(_entityService, _productService);
        }
    }
}
