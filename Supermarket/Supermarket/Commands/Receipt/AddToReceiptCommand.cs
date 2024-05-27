using Supermarket.Models;
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

        public AddToReceiptCommand(
            ReadonlyStockViewModel viewModel, 
            EntityStore<Receipt> entityStore)
        {
            _viewModel = viewModel;
            _entityStore = entityStore;
            _viewModel.PropertyChanged += OnViewModelProperyChanged;
        }
        public override void Execute(object? parameter)
        {
            ReceiptItem receiptItem = new ReceiptItem() 
            { 
                Item = _viewModel.Entity, 
                Quantity = int.Parse(_viewModel.ItemQuantity),
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
