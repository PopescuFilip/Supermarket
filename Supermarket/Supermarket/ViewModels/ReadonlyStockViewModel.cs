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
    public class ReadonlyStockViewModel : ViewModelBase
    {
        protected Stock _entity;
        public Stock Entity => _entity;
        public int Id => _entity.Id;
        public string Name => _entity.Product.Name;
        public string Barcode => _entity.Product.Barcode;
        public float SellPrice => _entity.SellPrice;
        public int Quantity => _entity.Quantity;
        public NavigationCommand RenavigationCommand { get; protected init; }
        public ReadonlyStockViewModel(EntityStore<Stock> entityStore)
        {
            _entity = entityStore.Entity;
            RenavigationCommand = new NavigationCommand(ViewType.SearchProduct);
        }
    }
}
