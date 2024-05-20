using Supermarket.Services;
using Supermarket.Stores;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CategoryListingViewModelFactory : IViewModelFactory<CategoryListingViewModel>
    {
        private readonly CategoryStore _categoryStore;
        private readonly CategoryService _categoryService;
        public CategoryListingViewModelFactory(CategoryStore categoryStore, CategoryService categoryService) 
        {
            _categoryStore = categoryStore;
            _categoryService = categoryService;
        }
        public CategoryListingViewModel CreateViewModel()
        {
            return new CategoryListingViewModel(_categoryStore, _categoryService);
        }
    }
}
