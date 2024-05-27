using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class ReceiptViewModel : EntityViewModel<Receipt>
    {
        public ObservableCollection<ReceiptItem> ReceiptItems { get; }
        public string Name => _entity.Cashier.Name;
        public float Total => ReceiptItems.Sum(r => r.Subtotal);
        public ReceiptViewModel(
            EntityStore<Receipt> entityStore, 
            IEntityService<Receipt> entityService,
            IEntityService<ReceiptItem> receiptItemsService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            
            ReceiptItems = new ObservableCollection<ReceiptItem>(receiptItemsService
                .GetAll()
                .Where(r => r.Id == _entity.Id));
        }
    }
}
