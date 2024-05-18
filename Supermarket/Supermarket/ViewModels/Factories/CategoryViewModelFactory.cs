using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CategoryViewModelFactory : IViewModelFactory<CategoryViewModel>
    {
        private readonly CategoryStore _categoryStore;
        private readonly CategoryService _categoryService;

        public CategoryViewModelFactory(CategoryStore categoryStore, CategoryService categoryService) 
        {
            _categoryStore = categoryStore;
            _categoryService = categoryService;
        }
        public CategoryViewModel CreateViewModel()
        {
            return new CategoryViewModel(_categoryStore, _categoryService);
        }
    }
}
