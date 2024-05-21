using Microsoft.EntityFrameworkCore.Storage;
using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class ProductListingViewModel : EntityListingViewModel<Product>
    {
        public ProductListingViewModel(EntityStore<Product> entityStore, IEntityService<Product> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            CreateEntityNavigationCommand = new NavigationCommand(ViewType.CreateProduct);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewProduct);
        }
    }
}
