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
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class SupplierListingViewModel : EntityListingViewModel<Supplier>
    {
        public SupplierListingViewModel(EntityStore<Supplier> supplierStore, IEntityService<Supplier> supplierService):
            base(supplierStore, supplierService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewSupplier);
            CreateEntityNavigationCommand = new NavigationCommand(ViewType.CreateSupplier);
        }
    }
}
