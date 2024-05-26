using Supermarket.Commands;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.ViewModels
{
    public class SearchProductViewModel : ViewModelBase
    {
        public NavigationCommand RenavigationCommand { get; }
        public NavigationCommand SearchByBarcodeNavigationCommand { get; }
        public NavigationCommand SearchByNameNavigationCommand { get; }
        public NavigationCommand SearchByExpirationDateNavigationCommand { get; }
        public NavigationCommand SearchByCategoryNavigationCommand { get; }
        public NavigationCommand SearchBySupplierNavigationCommand { get; }
        
        public SearchProductViewModel() 
        {
            RenavigationCommand = new NavigationCommand(ViewType.CashierOptions);
            SearchByBarcodeNavigationCommand = new NavigationCommand(ViewType.ProductSearchByBarcode);
            SearchByNameNavigationCommand = new NavigationCommand(ViewType.ProductSearchByName);
            SearchByExpirationDateNavigationCommand = new NavigationCommand(ViewType.ProductSearchByExpirationDate);
            SearchByCategoryNavigationCommand = new NavigationCommand(ViewType.ProductSearchByCategory);
            SearchBySupplierNavigationCommand = new NavigationCommand(ViewType.ProductSearchBySupplier);
        }
    }
}
