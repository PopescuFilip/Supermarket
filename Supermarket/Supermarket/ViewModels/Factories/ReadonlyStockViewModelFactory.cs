using Supermarket.Models;
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

        public ReadonlyStockViewModelFactory(
            EntityStore<Stock> entityStore,
            EntityStore<Receipt> receiptStore) 
        {
            _entityStore = entityStore;
            _receiptStore = receiptStore;
        }
        public ReadonlyStockViewModel CreateViewModel()
        {
            return new ReadonlyStockViewModel(_entityStore, _receiptStore);
        }
    }
}
