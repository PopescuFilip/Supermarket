using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class AddReceiptItemViewModelFactory : IViewModelFactory<AddReceiptItemViewModel>
    {
        public AddReceiptItemViewModelFactory() 
        { 
        }
        public AddReceiptItemViewModel CreateViewModel()
        {
            return new AddReceiptItemViewModel();
        }
    }
}
