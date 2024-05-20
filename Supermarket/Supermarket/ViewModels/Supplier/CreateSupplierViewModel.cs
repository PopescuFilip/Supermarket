using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CreateSupplierViewModel : CreateEntityViewModel<Supplier>
    {
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string? _countryOfOrigin;
        public string? CountryOfOrigin
        {
            get { return _countryOfOrigin; }
            set { _countryOfOrigin = value; OnPropertyChanged(nameof(CountryOfOrigin)); }
        }
        public CreateSupplierViewModel(IEntityService<Supplier> supplierService) :
            base(supplierService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.SupplierListing);
        }
        public override bool AllFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Name) &&
                !String.IsNullOrEmpty(CountryOfOrigin);
        }
        public override Supplier GetObjectFromFields()
        {
            return new Supplier()
            {
                Name = Name,
                CountryOfOrigin = CountryOfOrigin
            };
        }

        public override void ClearFields()
        {
            Name = null;
            CountryOfOrigin = null;
        }
    }
}
