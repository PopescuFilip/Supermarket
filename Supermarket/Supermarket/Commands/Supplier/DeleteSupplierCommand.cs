using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class DeleteSupplierCommand : CommandBase
    {
        private SupplierViewModel _supplierViewModel;
        private SupplierService _supplierService;

        public DeleteSupplierCommand(SupplierViewModel supplierViewModel, SupplierService supplierService)
        {
            _supplierViewModel = supplierViewModel;
            _supplierService = supplierService;
        }

        public override void Execute(object? parameter)
        {
            _supplierService.DeleteSupplier(_supplierViewModel.Supplier);
            NavigationService.Navigate(ViewType.SupplierListing);
        }
    }
}
