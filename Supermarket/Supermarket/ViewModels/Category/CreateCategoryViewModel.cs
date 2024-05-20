using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CreateCategoryViewModel : CreateEntityViewModel<Category>
    {
        private string? _name;

        public string? Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        public CreateCategoryViewModel(IEntityService<Category> categoryService):
            base(categoryService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.CategoryListing);
        }
        public override bool AllFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Name) && 
                base.AllFieldsCompleted();
        }

        public override Category GetObjectFromFields()
        {
            return new Category() { Name = Name };
        }

    }
}
