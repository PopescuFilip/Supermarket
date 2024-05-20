using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CategoryListingViewModel : ViewModelBase
    {
        private readonly CategoryStore _categoryStore;
        public ObservableCollection<Category> Categories { get; }
        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; ViewCategory(); }
        }

        public ICommand RenavigationCommand { get; }
        public ICommand CreateCategoryNavigationCommand { get; }
        public CategoryListingViewModel(CategoryStore categoryStore, CategoryService categoryService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            CreateCategoryNavigationCommand = new NavigationCommand(ViewType.CreateCategory);
            _categoryStore = categoryStore;
            Categories = new ObservableCollection<Category>(categoryService.GetAllCategories());
        }
        private void ViewCategory()
        {
            if (_selectedCategory == null)
                return;
            _categoryStore.Category = _selectedCategory;
            NavigationService.Navigate(ViewType.ViewCategory);
        }
    }
}
