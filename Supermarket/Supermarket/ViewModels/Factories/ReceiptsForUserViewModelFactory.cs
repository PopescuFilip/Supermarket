using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class ReceiptsForUserViewModelFactory : IViewModelFactory<ReceiptsForUserViewModel>
    {
        private readonly EntityStore<User> _entityStore;
        private readonly EntityStore<Receipt> _receiptStore;
        private readonly IEntityService<Receipt> _entityService;

        public ReceiptsForUserViewModelFactory(
            EntityStore<User> entityStore,
            EntityStore<Receipt> receiptStore,
            IEntityService<Receipt> entityService) 
        {
            _entityStore = entityStore;
            _receiptStore = receiptStore;
            _entityService = entityService;
        }
        public ReceiptsForUserViewModel CreateViewModel()
        {
            return new ReceiptsForUserViewModel(_entityStore, _receiptStore, _entityService);
        }
    }
}
