using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CreateCategoryViewModelFactory : IViewModelFactory<CreateCategoryViewModel>
    {
        private readonly CategoryService _categoryService;
        public CreateCategoryViewModelFactory(CategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        public CreateCategoryViewModel CreateViewModel()
        {
            return new CreateCategoryViewModel(_categoryService);
        }
    }
}
