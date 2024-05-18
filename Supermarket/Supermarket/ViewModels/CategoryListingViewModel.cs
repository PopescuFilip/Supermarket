using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
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
        public ObservableCollection<Category> Categories { get; }
        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; ViewCategory(); }
        }

        public ICommand RenavigationCommand { get; }
        public ICommand CreateCategoryNavigationCommand {  get; }
        public CategoryListingViewModel(CategoryService categoryService) 
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            CreateCategoryNavigationCommand = new NavigationCommand(ViewType.CreateCategory);
            Categories = new ObservableCollection<Category>(categoryService.GetAllCategories());
        }
        private void ViewCategory()
        {
            if (_selectedCategory == null)
                return;
            MessageBox.Show($"selected {_selectedCategory.Name}");
            //NavigationService.Navigate(ViewType.ViewCategory);
        }
    }
}
