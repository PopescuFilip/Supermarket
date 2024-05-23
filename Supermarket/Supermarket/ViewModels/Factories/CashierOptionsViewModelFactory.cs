using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class CashierOptionsViewModelFactory : IViewModelFactory<CashierOptionsViewModel>
    {
        public CashierOptionsViewModel CreateViewModel()
        {
            return new CashierOptionsViewModel();
        }
    }
}
