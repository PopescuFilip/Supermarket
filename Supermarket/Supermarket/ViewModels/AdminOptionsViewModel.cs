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
    public class AdminOptionsViewModel : ViewModelBase
    {
        public ICommand RenavigationCommand { get; }
        public ICommand ProductsNavigationCommand { get; }
        public ICommand SuppliersNavigationCommand { get; }
        public ICommand CategoriesNavigationCommand { get; }
        public AdminOptionsViewModel() 
        {
            ProductsNavigationCommand = new NavigationCommand(ViewType.ProductListing);
            SuppliersNavigationCommand = new NavigationCommand(ViewType.SupplierListing);
            CategoriesNavigationCommand = new NavigationCommand(ViewType.CategoryListing);
            RenavigationCommand = new NavigationCommand(ViewType.Login);
        }
    }
}
