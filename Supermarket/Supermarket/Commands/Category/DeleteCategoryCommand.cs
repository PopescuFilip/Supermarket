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
    public class DeleteCategoryCommand : CommandBase
    {
        private readonly CategoryViewModel _categoryViewModel;
        private readonly IEntityService<Category> _categoryService;

        public DeleteCategoryCommand(CategoryViewModel categoryViewModel, IEntityService<Category> categoryService)
        {
            _categoryViewModel = categoryViewModel;
            _categoryService = categoryService;
        }
        public override void Execute(object? parameter)
        {
            _categoryService.Delete(_categoryViewModel.Category);
            NavigationService.Navigate(ViewType.CategoryListing);
        }
    }
}
