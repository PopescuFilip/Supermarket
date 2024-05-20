using Supermarket.Commands;
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
    public class CategoryViewModel : EntityViewModel<Category>
    {
        public string Name
        {
            get => _entity.Name;
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public CategoryViewModel(EntityStore<Category> categoryStore, IEntityService<Category> categoryService):
            base(categoryStore, categoryService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.CategoryListing);
        }

        public override bool AllFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Name);
        }
    }
}
