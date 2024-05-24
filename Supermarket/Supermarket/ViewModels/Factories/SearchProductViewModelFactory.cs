using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class SearchProductViewModelFactory : IViewModelFactory<SearchProductViewModel>
    {
        public SearchProductViewModelFactory() 
        {
            
        }
        public SearchProductViewModel CreateViewModel()
        {
            return new SearchProductViewModel();
        }
    }
}
