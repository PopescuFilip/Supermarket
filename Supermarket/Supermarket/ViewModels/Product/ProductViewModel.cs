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
    public class ProductViewModel : EntityViewModel<Product>
    {
        public string Name
        {
            get => _entity.Name;
            set { _entity.Name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string Barcode
        {
            get => _entity.Barcode;
            set { _entity.Barcode = value; OnPropertyChanged(nameof(Barcode)); }
        }
        public string Category => _entity.Category.Name;
        public string Supplier => _entity.Supplier.Name;
        public ProductViewModel(EntityStore<Product> entityStore, IEntityService<Product> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.ProductListing);
        }
        public override bool AllFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Name) &&
                !String.IsNullOrEmpty(Barcode) &&
                base.AllFieldsCompleted();
        }
        public override bool CanBeUpdated()
        {
            return Product.IsValidBarcode(Barcode) &&
                base.CanBeUpdated();
        }
        public override bool CanBeDeleted()
        {
            return !_entity.Stocks.Any(s => s.IsActive) &&
                base.CanBeDeleted();
        }

    }
}
