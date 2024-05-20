using Supermarket.Models;
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
        private readonly EntityStore<Category> _categoryStore;
        private readonly IEntityService<Category> _categoryService;
        public CategoryListingViewModelFactory(EntityStore<Category> categoryStore, IEntityService<Category> categoryService) 
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
