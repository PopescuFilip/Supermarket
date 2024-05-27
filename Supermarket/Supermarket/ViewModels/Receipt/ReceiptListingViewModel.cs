using Supermarket.Commands;
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
    public class ReceiptListingViewModel : EntityListingViewModel<Receipt>
    {
        public ReceiptListingViewModel(EntityStore<Receipt> entityStore, IEntityService<Receipt> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewReceipt);
        }
    }
}
