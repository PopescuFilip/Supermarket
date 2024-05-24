using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class AddReceiptViewModelFactory : IViewModelFactory<AddReceiptViewModel>
    {
        public AddReceiptViewModelFactory()
        {
        }

        public AddReceiptViewModel CreateViewModel()
        {
            return new AddReceiptViewModel();
        }
    }
}
