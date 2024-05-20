using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CreateSupplierViewModelFactory : IViewModelFactory<CreateSupplierViewModel>
    {
        private readonly SupplierService _supplierService;

        public CreateSupplierViewModelFactory(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public CreateSupplierViewModel CreateViewModel()
        {
            return new CreateSupplierViewModel(_supplierService);
        }
    }
}
