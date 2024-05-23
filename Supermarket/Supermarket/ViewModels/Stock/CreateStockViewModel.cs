using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Supermarket.ViewModels
{
    public class CreateStockViewModel : CreateEntityViewModel<Stock>
    {
        public ObservableCollection<Product> Products { get; init; }
        
        private string _buyPrice;
        public string BuyPrice
        {
            get { return _buyPrice; }
            set { _buyPrice = value; OnPropertyChanged(nameof(BuyPrice)); }
        }
        private string _sellPrice;
        public string SellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; OnPropertyChanged(nameof(SellPrice)); }
        }
        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }
        private DateTime? _expirationDate;

        public DateTime? ExpirationDate
        {
            get { return  _expirationDate; }
            set {  _expirationDate = value; OnPropertyChanged(nameof(ExpirationDate)); }
        }


        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(nameof(SelectedProduct)); }
        }
        public DateTime Today { get; set; }
        public DateTime TodayPlus10Years { get; set; }
        private float _markup;
        public CreateStockViewModel(IEntityService<Stock> entityService, IEntityService<Product> productService) : 
            base(entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.StockListing);
            Products = new ObservableCollection<Product>(productService.GetAll());
            
            Today = DateTime.Now;
            TodayPlus10Years = DateTime.Now.AddYears(10);

            _markup = float.Parse(ConfigurationManager.AppSettings.Get("markup"));
        }
        public override bool CanCreate()
        {
            if (!int.TryParse(Quantity, out _))
                return false;
            if(!float.TryParse(BuyPrice, out _)) 
                return false;
            return ExpirationDate.HasValue &&
                base.CanCreate();
        }
        public override Stock GetObjectFromFields()
        {
            return new Stock()
            {
                BuyPrice = float.Parse(BuyPrice),
                SellPrice = float.Parse(SellPrice),
                Quantity = int.Parse(Quantity),
                ExpirationDate = DateOnly.FromDateTime(ExpirationDate.Value),
                Product = SelectedProduct
            };

        }
    }
}
