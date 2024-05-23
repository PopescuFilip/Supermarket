using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class ViewPricesForCategoryViewModelFactory : IViewModelFactory<ViewPricesForCategoryViewModel>
    {
        private readonly IEntityService<Category> _categoryService;
        private readonly IEntityService<Product> _productService;

        public ViewPricesForCategoryViewModelFactory(
            IEntityService<Category> categoryService,
            IEntityService<Product> productService) 
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public ViewPricesForCategoryViewModel CreateViewModel()
        {
            return new ViewPricesForCategoryViewModel(_categoryService, _productService);
        }
    }
}
