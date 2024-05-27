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
    public class MostValuableReceiptViewModelFactory : IViewModelFactory<MostValuableReceiptViewModel>
    {
        private readonly EntityStore<Receipt> _entityStore;
        private readonly IEntityService<Receipt> _entityService;
        private readonly IEntityService<ReceiptItem> _receiptItemService;

        public MostValuableReceiptViewModelFactory(
            EntityStore<Receipt> entityStore,
            IEntityService<Receipt> entityService,
            IEntityService<ReceiptItem> receiptItemService) 
        {
            _entityStore = entityStore;
            _entityService = entityService;
            _receiptItemService = receiptItemService;
        }
        public MostValuableReceiptViewModel CreateViewModel()
        {
            return new MostValuableReceiptViewModel(_entityStore, _entityService, _receiptItemService);
        }
    }
}
