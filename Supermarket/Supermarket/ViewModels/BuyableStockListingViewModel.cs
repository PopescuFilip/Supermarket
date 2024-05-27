using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class BuyableStockListingViewModel : EntityListingViewModel<Stock>
    {
        public BuyableStockListingViewModel(EntityStore<Stock> entityStore, IEntityService<Stock> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.SearchProduct);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ReadonlyViewStock);

            Entities = new ObservableCollection<Stock>(entityStore.Entities);
        }
    }
}
