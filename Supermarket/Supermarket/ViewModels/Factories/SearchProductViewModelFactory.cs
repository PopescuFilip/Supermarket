using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class SearchProductViewModelFactory : IViewModelFactory<SearchProductViewModel>
    {
        private readonly IEntityService<Supplier> _supplierService;
        private readonly IEntityService<Category> _categoryService;
        private readonly IEntityService<Stock> _stockService;
        private readonly EntityStore<Stock> _entityStore;

        public SearchProductViewModelFactory(
            IEntityService<Supplier> supplierService,
            IEntityService<Category> categoryService,
            IEntityService<Stock> stockService,
            EntityStore<Stock> entityStore) 
        {
            _supplierService = supplierService;
            _categoryService = categoryService;
            _stockService = stockService;
            _entityStore = entityStore;
        }
        public SearchProductViewModel CreateViewModel()
        {
            return new SearchProductViewModel(
                _supplierService, 
                _categoryService, 
                _stockService, 
                _entityStore);
        }
    }
}
