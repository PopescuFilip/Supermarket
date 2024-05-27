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
    public class SupplierViewModel : EntityViewModel<Supplier>
    {
        public string Name
        {
            get => _entity.Name;
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CountryOfOrigin
        {
            get => _entity.CountryOfOrigin;
            set { _entity.CountryOfOrigin = value; OnPropertyChanged(nameof(CountryOfOrigin)); }
        }
        public NavigationCommand ViewProductsCommand { get; }

        private readonly bool _deleteable;
        public SupplierViewModel(
            EntityStore<Supplier> supplierStore, 
            IEntityService<Supplier> supplierService,
            IEntityService<Product> productService) :
            base(supplierStore, supplierService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.SupplierListing);
            ViewProductsCommand = new NavigationCommand(ViewType.ViewProductsForSupplier);

            _deleteable = !productService
                .GetAll()
                .Any(p => p.Supplier.Id == _entity.Id);
        }

        public override bool AllFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Name) &&
                !String.IsNullOrEmpty(CountryOfOrigin);
        }

        public override bool CanBeDeleted()
        {
            return _deleteable &&
                base.CanBeDeleted();
        }
    }
}
