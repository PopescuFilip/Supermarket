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
    public class CashierOptionsViewModel : ViewModelBase
    {
        public NavigationCommand RenavigationCommand { get; }
        public NavigationCommand SearchProductNavigationCommand { get; }
        public NavigationCommand AddReceiptNavigationCommand { get; }
        public NavigationCommand AddReceiptItemNavigationCommand { get; }
        public CashierOptionsViewModel() 
        {
            RenavigationCommand = new NavigationCommand(ViewType.Login);
            SearchProductNavigationCommand = new NavigationCommand(ViewType.SearchProduct);
            AddReceiptNavigationCommand = new NavigationCommand(ViewType.AddReceipt);
            AddReceiptItemNavigationCommand = new NavigationCommand(ViewType.AddReceiptItem);
        }
    }
}
