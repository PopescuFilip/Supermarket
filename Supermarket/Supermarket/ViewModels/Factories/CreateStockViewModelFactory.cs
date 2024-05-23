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

        public CreateStockViewModelFactory(IEntityService<Stock> entityService)
        {
            _entityService = entityService;
        }
        public CreateStockViewModel CreateViewModel()
        {
            return new CreateStockViewModel(_entityService);
        }
    }
}
