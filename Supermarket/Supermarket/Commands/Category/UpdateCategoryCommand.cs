using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class UpdateCategoryCommand : CommandBase
    {
        private readonly CategoryViewModel _categoryViewModel;
        private readonly IEntityService<Category> _categoryService;

        public UpdateCategoryCommand(CategoryViewModel categoryViewModel, IEntityService<Category> categoryService)
        {
            _categoryViewModel = categoryViewModel;
            _categoryService = categoryService;
            _categoryViewModel.PropertyChanged += OnViewModelProperyChanged;
        }
        public override void Execute(object? parameter)
        {
            _categoryService.Update(_categoryViewModel.Category);
            NavigationService.Navigate(ViewType.CategoryListing);
        }

        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CategoryViewModel.Name))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_categoryViewModel.Name) &&
                   base.CanExecute(parameter);
        }
    }
}
