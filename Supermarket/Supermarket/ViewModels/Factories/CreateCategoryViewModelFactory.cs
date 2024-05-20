using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CreateCategoryViewModelFactory : IViewModelFactory<CreateCategoryViewModel>
    {
        private readonly IEntityService<Category> _categoryService;
        public CreateCategoryViewModelFactory(IEntityService<Category> categoryService) 
        {
            _categoryService = categoryService;
        }
        public CreateCategoryViewModel CreateViewModel()
        {
            return new CreateCategoryViewModel(_categoryService);
        }
    }
}
