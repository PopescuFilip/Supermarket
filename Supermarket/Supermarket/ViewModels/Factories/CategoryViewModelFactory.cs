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
    public class CategoryViewModelFactory : IViewModelFactory<CategoryViewModel>
    {
        private readonly EntityStore<Category> _categoryStore;
        private readonly IEntityService<Category> _categoryService;
        private readonly IEntityService<Product> _productService;

        public CategoryViewModelFactory(
            EntityStore<Category> categoryStore,
            IEntityService<Category> categoryService,
            IEntityService<Product> productService) 
        {
            _categoryStore = categoryStore;
            _categoryService = categoryService;
            _productService = productService;
        }
        public CategoryViewModel CreateViewModel()
        {
            return new CategoryViewModel(_categoryStore, _categoryService, _productService);
        }
    }
}
