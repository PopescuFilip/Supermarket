using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class CreateStockViewModel : CreateEntityViewModel<Stock>
    {
        public CreateStockViewModel(IEntityService<Stock> entityService) : 
            base(entityService)
        {
        }
    }
}
