using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Commands
{
    public class CreateCategoryCommand : CommandBase
    {
        private readonly CreateCategoryViewModel _viewModel;
        private readonly CategoryService _categoryService;
        public CreateCategoryCommand(CreateCategoryViewModel viewModel, CategoryService categoryService)
        {
            _viewModel = viewModel;
            _categoryService = categoryService;
            _viewModel.PropertyChanged += OnViewModelProperyChanged;
        }
        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateCategoryViewModel.Name))
            {
                OnCanExecutedChanged();
            }
        }
        public override void Execute(object? parameter)
        {
            _categoryService.CreateCategory(new Category() { Name = _viewModel.Name });
            NavigationService.Navigate(ViewType.CategoryListing);
            //MessageBox.Show("Category added");
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Name) &&
                   base.CanExecute(parameter);
        }
    }
}
