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
    public class SupplierListingViewModel : ViewModelBase
    {
        private readonly SupplierStore _supplierStore;
        public ObservableCollection<Supplier> Suppliers { get; }
        private Supplier? _selectedSupplier;

        public Supplier? SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; ViewSupplier(); }
        }
        public ICommand RenavigationCommand { get; }
        public ICommand CreateSupplierNavigationCommand { get; }
        public SupplierListingViewModel(SupplierStore supplierStore, SupplierService supplierService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            CreateSupplierNavigationCommand = new NavigationCommand(ViewType.CreateSupplier);
            _supplierStore = supplierStore;
            Suppliers = new ObservableCollection<Supplier>(supplierService.GetAllSuppliers());
        }

        private void ViewSupplier()
        {
            if (_selectedSupplier == null)
                return;
            _supplierStore.Supplier = _selectedSupplier;
            NavigationService.Navigate(ViewType.ViewSupplier);
        }
        
    }
}
