using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class SupplierListingViewModelFactory : IViewModelFactory<SupplierListingViewModel>
    {
        public SupplierListingViewModel CreateViewModel()
        {
            return new SupplierListingViewModel();
        }
    }
}
