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
    public class CreateReceiptViewModelFactory : IViewModelFactory<CreateReceiptViewModel>
    {
        private readonly AuthenticationService _authenticationService;
        private readonly EntityStore<Receipt> _entityStore;
        private readonly IEntityService<Receipt> _entityService;

        public CreateReceiptViewModelFactory(
            AuthenticationService authenticationService,
            EntityStore<Receipt> entityStore,
            IEntityService<Receipt> entityService)
        {
            _authenticationService = authenticationService;
            _entityStore = entityStore;
            _entityService = entityService;
        }

        public CreateReceiptViewModel CreateViewModel()
        {
            return new CreateReceiptViewModel(_authenticationService, _entityStore, _entityService);
        }
    }
}
