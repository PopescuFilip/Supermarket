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

        public ReadonlyStockViewModelFactory(EntityStore<Stock> entityStore) 
        {
            _entityStore = entityStore;
        }
        public ReadonlyStockViewModel CreateViewModel()
        {
            return new ReadonlyStockViewModel(_entityStore);
        }
    }
}
