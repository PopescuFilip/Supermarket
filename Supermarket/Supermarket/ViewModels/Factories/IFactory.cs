using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public interface IFactory
    {
        ViewModelBase Create(ViewType viewType);
    }
}
