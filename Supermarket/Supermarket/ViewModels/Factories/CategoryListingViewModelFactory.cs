using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CategoryListingViewModelFactory : IViewModelFactory<CategoryListingViewModel>
    {
        public CategoryListingViewModel CreateViewModel()
        {
            return new CategoryListingViewModel();
        }
    }
}
