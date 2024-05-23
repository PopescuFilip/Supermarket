using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class StockViewModel : EntityViewModel<Stock>
    {
        public StockViewModel(EntityStore<Stock> entityStore, IEntityService<Stock> entityService) : 
            base(entityStore, entityService)
        {
        }
    }
}
