using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class AdminOptionsViewModelFactory : IViewModelFactory<AdminOptionsViewModel>
    {
        public AdminOptionsViewModel CreateViewModel()
        {
            return new AdminOptionsViewModel();
        }
    }
}
