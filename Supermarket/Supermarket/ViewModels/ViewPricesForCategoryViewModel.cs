using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class ViewPricesForCategoryViewModel : ViewModelBase
    {
        public List<Tuple<string, float>> CategoriesWithPrices { get; }
        public NavigationCommand RenavigationCommand { get; }
        public ViewPricesForCategoryViewModel(
            IEntityService<Category> categoryService,
            IEntityService<Product> productService) 
        {
            CategoriesWithPrices = [];
            RenavigationCommand = new NavigationCommand(ViewType.CategoryListing);
            LoadCategoriesWithPrices(categoryService, productService);
        }
        private void LoadCategoriesWithPrices(
            IEntityService<Category> categoryService,
            IEntityService<Product> productService)
        {
            var products = productService.GetAll();
            foreach (var category in categoryService.GetAll())
            {
                float price = 0;
                foreach (var product in products)
                {
                    if (product.Category.Id != category.Id)
                        continue;
                    foreach (var stock in product.Stocks)
                    {
                        price += stock.SellPrice * stock.Quantity;
                    }
                }
                var categoryWithPrice = Tuple.Create(category.Name, price);
                CategoriesWithPrices.Add(categoryWithPrice);
            }
        }
    }
}
