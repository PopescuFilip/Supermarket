﻿using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CategoryListingViewModelFactory : IViewModelFactory<CategoryListingViewModel>
    {
        private readonly CategoryService _categoryService;
        public CategoryListingViewModelFactory(CategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        public CategoryListingViewModel CreateViewModel()
        {
            return new CategoryListingViewModel(_categoryService);
        }
    }
}
