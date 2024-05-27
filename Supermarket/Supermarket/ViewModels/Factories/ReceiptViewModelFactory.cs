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
    public class ReceiptViewModelFactory : IViewModelFactory<ReceiptViewModel>
    {
        private readonly EntityStore<Receipt> _entityStore;
        private readonly IEntityService<Receipt> _entityService;
        private readonly IEntityService<ReceiptItem> _receiptItemsService;

        public ReceiptViewModelFactory(
            EntityStore<Receipt> entityStore, 
            IEntityService<Receipt> entityService,
            IEntityService<ReceiptItem> receiptItemsService) 
        {
            _entityStore = entityStore;
            _entityService = entityService;
            _receiptItemsService = receiptItemsService;
        }
        public ReceiptViewModel CreateViewModel()
        {
            return new ReceiptViewModel(_entityStore, _entityService, _receiptItemsService);
        }
    }
}
