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
    public class ReceiptsForUserViewModel : EntityListingViewModel<Receipt>
    {
        public ReceiptsForUserViewModel(
            EntityStore<User> entityStore,
            EntityStore<Receipt> receiptStore,
            IEntityService<Receipt> entityService):
            base(receiptStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.ViewUser);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewReceipt);

            Entities = new ObservableCollection<Receipt>(entityService
                .GetAll()
                .Where(r => r.Cashier.Id == entityStore.Entity.Id));
            
        }
    }
}
