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
        public ICommand RenavigationCommand { get; }
        public CashierOptionsViewModel() 
        {
            RenavigationCommand = new NavigationCommand(ViewType.Login);
        }
    }
}
