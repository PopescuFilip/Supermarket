using Supermarket.Commands;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CreateCategoryViewModel : ViewModelBase
    {
        private string? _name;

        public string? Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public ICommand CreateCategoryCommand { get; }
        public CreateCategoryViewModel(CategoryService categoryService) 
        {
            CreateCategoryCommand = new CreateCategoryCommand(this, categoryService);
        }
    }
}
