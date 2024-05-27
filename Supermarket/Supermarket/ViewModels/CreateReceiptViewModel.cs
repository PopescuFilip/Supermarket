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
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CreateReceiptViewModel : ViewModelBase
    {
        private readonly Receipt _receipt;
        public Receipt Receipt => _receipt;
        public ObservableCollection<ReceiptItem> ReceiptItems { get; }
        public float Total => _receipt.Total; 
        public NavigationCommand RenavigationCommand { get; }
        public NavigationCommand AddReceiptItemNavigationCommand { get; }
        public ICommand CreateReceiptCommand { get; }
        public ICommand DeleteReceiptCommand { get; }
        public CreateReceiptViewModel(
            AuthenticationService authenticationService,
            EntityStore<Receipt> entityStore,
            IEntityService<Receipt> entityService) 
        {
            if (entityStore.Entity == null)
            {
                entityStore.Entity = new Receipt() { Cashier = authenticationService.ConnectedUser };
            }
            _receipt = entityStore.Entity;
            ReceiptItems = new ObservableCollection<ReceiptItem>(_receipt.Items);

            CreateReceiptCommand = new CreateReceiptCommand(this, entityService, entityStore);
            DeleteReceiptCommand = new DeleteReceiptCommand(this, entityStore);
            RenavigationCommand = new NavigationCommand(ViewType.CashierOptions);
            AddReceiptItemNavigationCommand = new NavigationCommand(ViewType.SearchProduct);
        }
    }
}
