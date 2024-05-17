using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public interface IViewModelFactory<T> where T :ViewModelBase
    {
        T CreateViewModel();
    }
}
