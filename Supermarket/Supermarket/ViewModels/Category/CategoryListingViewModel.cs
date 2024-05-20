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
    public class CategoryListingViewModel : EntityListingViewModel<Category>
    {
        public CategoryListingViewModel(EntityStore<Category> categoryStore, IEntityService<Category> categoryService):
            base(categoryStore, categoryService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewCategory);
            CreateEntityNavigationCommand = new NavigationCommand(ViewType.CreateCategory);
        }
    }
}
