using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class AddToReceiptCommand : CommandBase
    {
        private readonly ReadonlyStockViewModel _viewModel;
        private readonly EntityStore<Receipt> _entityStore;
        private readonly IEntityService<Stock> _entityService;

        public AddToReceiptCommand(
            ReadonlyStockViewModel viewModel, 
            EntityStore<Receipt> entityStore,
            IEntityService<Stock> entityService)
        {
            _viewModel = viewModel;
            _entityStore = entityStore;
            _entityService = entityService;
            _viewModel.PropertyChanged += OnViewModelProperyChanged;
        }
        public override void Execute(object? parameter)
        {
            int quantity = int.Parse(_viewModel.ItemQuantity);
            _viewModel.Entity.Quantity -= quantity;
            _entityService.Update(_viewModel.Entity);

            ReceiptItem receiptItem = new ReceiptItem() 
            { 
                Item = _viewModel.Entity, 
                Quantity = quantity,
                Receipt = _entityStore.Entity
            };

            _entityStore.Entity.Items.Add(receiptItem);
            _viewModel.CreateReceiptNavigationCommand.Execute(null);
        }
        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }
        public override bool CanExecute(object? parameter)
        {
            return _viewModel.ValidQuantity() &&
                   base.CanExecute(parameter);
        }
    }
}
