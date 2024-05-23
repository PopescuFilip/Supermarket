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
    public class StockListingViewModelFactory : IViewModelFactory<StockListingViewModel>
    {
        private readonly EntityStore<Stock> _entityStore;
        private readonly IEntityService<Stock> _entityService;

        public StockListingViewModelFactory(EntityStore<Stock> entityStore, IEntityService<Stock> entityService)
        {
            _entityStore = entityStore;
            _entityService = entityService;
        }
        public StockListingViewModel CreateViewModel()
        {
            return new StockListingViewModel(_entityStore, _entityService);
        }
    }
}
