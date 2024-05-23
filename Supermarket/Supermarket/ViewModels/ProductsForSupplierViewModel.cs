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

namespace Supermarket.ViewModels
{
    public class ProductsForSupplierViewModel : ViewModelBase
    {
        public List<IGrouping<Category, Product>> Products { get; init; }
        public NavigationCommand RenavigationCommand { get; }
        public ProductsForSupplierViewModel(
            EntityStore<Supplier> entityStore, 
            IEntityService<Product> entityService) 
        {
            RenavigationCommand = new NavigationCommand(ViewType.ViewSupplier);

            Products = entityService
                .GetAll()
                .Where(p => p.Supplier.Id == entityStore.Entity.Id)
                .GroupBy(p => p.Category)
                .ToList();
            
            //foreach (var product in Products) 
            //{
            //    product.Key
            //    foreach (var item in product)
            //    {
            //        item.Name
            //    }
            //}
        }
    }
}
