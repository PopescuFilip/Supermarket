using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class ReceiptListingViewModelFactory : IViewModelFactory<ReceiptListingViewModel>
    {
        private readonly EntityStore<Receipt> _entityStore;
        private readonly IEntityService<Receipt> _entityService;

        public ReceiptListingViewModelFactory(EntityStore<Receipt> entityStore, IEntityService<Receipt> entityService) 
        {
            _entityStore = entityStore;
            _entityService = entityService;
        }
        public ReceiptListingViewModel CreateViewModel()
        {
            return new ReceiptListingViewModel(_entityStore, _entityService);
        }
    }
}
