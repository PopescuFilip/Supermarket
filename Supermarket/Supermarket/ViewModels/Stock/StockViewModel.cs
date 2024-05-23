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
    public class StockViewModel : EntityViewModel<Stock>
    {
        public String Product => _entity.Product.Name;
        public float BuyPrice => _entity.BuyPrice;
        private string _sellPrice;
        public string SellPrice
        {
            get => _sellPrice;
            set
            {
                _sellPrice = value;
                UpdateSellPrice();
                OnPropertyChanged(nameof(SellPrice));
            }
        }
        public int Quantity => _entity.Quantity;
        public DateOnly ExpirationDate => _entity.ExpirationDate;
        public StockViewModel(EntityStore<Stock> entityStore, IEntityService<Stock> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.StockListing);
            SellPrice = _entity.SellPrice.ToString();
        }
        private void UpdateSellPrice()
        {
            if (!IsValidSellPrice())
                return;
            _entity.SellPrice = float.Parse(SellPrice);
        }
        private bool IsValidSellPrice()
        {
            return float.TryParse(SellPrice, out _);
        }
        public override bool CanBeDeleted()
        {
            return base.CanBeDeleted();
        }
        public override bool CanBeUpdated()
        {
            return IsValidSellPrice() && 
                _entity.SellPrice > _entity.BuyPrice &&
                base.CanBeUpdated();
        }
    }
}
