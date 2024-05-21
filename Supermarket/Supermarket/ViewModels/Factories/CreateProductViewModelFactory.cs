using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CreateProductViewModelFactory : IViewModelFactory<CreateProductViewModel>
    {
        private readonly IEntityService<Product> _entityService;
        private readonly IEntityService<Category> _categoryService;
        private readonly IEntityService<Supplier> _supplierService;

        public CreateProductViewModelFactory(
            IEntityService<Product> entityService,
            IEntityService<Category> categoryService,
            IEntityService<Supplier> supplierService) 
        {
            this._entityService = entityService;
            this._categoryService = categoryService;
            this._supplierService = supplierService;
        }  
        public CreateProductViewModel CreateViewModel()
        {
            return new CreateProductViewModel(_entityService, _categoryService, _supplierService);
        }
    }
}
