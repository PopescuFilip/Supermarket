using Supermarket.Commands;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CreateSupplierViewModel : ViewModelBase
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

        public ICommand RenavigationCommand { get; }
        public ICommand CreateSupplierCommand { get; }
        public CreateSupplierViewModel(SupplierService supplierService) 
        {
            CreateSupplierCommand = new CreateSupplierCommand(this, supplierService);
            RenavigationCommand = new NavigationCommand(ViewType.SupplierListing);
        }
    }
}
