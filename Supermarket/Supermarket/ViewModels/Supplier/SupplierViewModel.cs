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
    public class SupplierViewModel : ViewModelBase
    {
        private Supplier _supplier;
        public Supplier Supplier => _supplier;
        public int Id => _supplier.Id;
        public string Name
        {
            get => _supplier.Name;
            set
            {
                _supplier.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ICommand RenavigationCommand { get; }
        public ICommand UpdateSupplierCommand { get; }
        public ICommand DeleteSupplierCommand { get; }
        public SupplierViewModel(SupplierStore supplierStore, IEntityService<Supplier> supplierService) 
        {
            _supplier = supplierStore.Supplier;
            RenavigationCommand = new NavigationCommand(ViewType.SupplierListing);
            UpdateSupplierCommand = new UpdateSupplierCommand(this, supplierService);
            DeleteSupplierCommand = new DeleteSupplierCommand(this, supplierService);
        }
    }
}
