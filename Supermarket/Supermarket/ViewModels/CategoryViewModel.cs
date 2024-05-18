﻿using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        private Category _category;
        public int Id => _category.Id;
        public string Name 
        {
            get => _category.Name;
            set
            {
                _category.Name = value;
            }
        }
        public ICommand RenavigationCommand { get; }
        public CategoryViewModel(CategoryStore categoryStore, CategoryService categoryService) 
        {
            _category = categoryStore.Category;
            RenavigationCommand = new NavigationCommand(ViewType.CategoryListing);
        }
    }
}