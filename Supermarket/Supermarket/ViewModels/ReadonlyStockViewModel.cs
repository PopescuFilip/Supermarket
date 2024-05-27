using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public DateOnly ExpirationDate => _entity.ExpirationDate;

        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set { _itemQuantity = value; OnPropertyChanged(nameof(ItemQuantity)); }
        }

        public NavigationCommand RenavigationCommand { get; protected init; }
        public NavigationCommand CreateReceiptNavigationCommand { get; }
        public ICommand AddToReceiptCommand { get; }
        public ReadonlyStockViewModel(
            EntityStore<Stock> entityStore,
            EntityStore<Receipt> receiptStore,
            IEntityService<Stock> entityService)
        {
            _entity = entityStore.Entity;
            CreateReceiptNavigationCommand = new NavigationCommand(ViewType.CreateReceipt);
            RenavigationCommand = new NavigationCommand(ViewType.SearchProduct);
            AddToReceiptCommand = new AddToReceiptCommand(this, receiptStore, entityService);
        }
        public bool ValidQuantity()
        {
            if(!int.TryParse(ItemQuantity, out var quantity))
                return false;
            if(quantity <= 0 || quantity > Quantity)
                return false;

            return true;
        }
    }
}
