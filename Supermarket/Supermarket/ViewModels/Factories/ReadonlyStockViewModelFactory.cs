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
    public class ReadonlyStockViewModelFactory : IViewModelFactory<ReadonlyStockViewModel>
    {
        private readonly EntityStore<Stock> _entityStore;
        private readonly EntityStore<Receipt> _receiptStore;
        private readonly IEntityService<Stock> _entityService;

        public ReadonlyStockViewModelFactory(
            EntityStore<Stock> entityStore,
            EntityStore<Receipt> receiptStore,
            IEntityService<Stock> entityService) 
        {
            _entityStore = entityStore;
            _receiptStore = receiptStore;
            _entityService = entityService;
        }
        public ReadonlyStockViewModel CreateViewModel()
        {
            return new ReadonlyStockViewModel(_entityStore, _receiptStore, _entityService);
        }
    }
}
