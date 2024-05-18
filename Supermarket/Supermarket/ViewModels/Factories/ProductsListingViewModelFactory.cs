using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    class ProductsListingViewModelFactory : IViewModelFactory<ProductListingViewModel>
    {
        public ProductListingViewModel CreateViewModel()
        {
            return new ProductListingViewModel();
        }
    }
}
