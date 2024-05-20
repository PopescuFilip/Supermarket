using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class SupplierViewModel : EntityViewModel<Supplier>
    {
        public string Name
        {
            get => _entity.Name;
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public SupplierViewModel(EntityStore<Supplier> supplierStore, IEntityService<Supplier> supplierService) :
            base(supplierStore, supplierService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.SupplierListing);
        }

        public override bool AllFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Name);
        }
    }
}
