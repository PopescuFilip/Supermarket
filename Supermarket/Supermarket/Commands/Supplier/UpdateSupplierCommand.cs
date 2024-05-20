using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Supermarket.Commands
{
    public class UpdateSupplierCommand : CommandBase
    {
        private SupplierViewModel _supplierViewModel;
        private SupplierService _supplierService;

        public UpdateSupplierCommand(SupplierViewModel supplierViewModel, SupplierService supplierService)
        {
            _supplierViewModel = supplierViewModel;
            _supplierService = supplierService;
            _supplierViewModel.PropertyChanged += OnViewModelProperyChanged;
        }
        public override void Execute(object? parameter)
        {
            _supplierService.UpdateSupplier(_supplierViewModel.Supplier);
            NavigationService.Navigate(ViewType.SupplierListing);
        }
        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CategoryViewModel.Name))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_supplierViewModel.Name) &&
                   base.CanExecute(parameter);
        }
    }
}
