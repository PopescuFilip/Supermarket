using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class DeleteReceiptCommand : CommandBase
    {
        private readonly CreateReceiptViewModel _viewModel;
        private readonly EntityStore<Receipt> _entityStore;

        public DeleteReceiptCommand(
            CreateReceiptViewModel viewModel,
            EntityStore<Receipt> entityStore)
        {
            _viewModel = viewModel;
            _entityStore = entityStore;
        }
        public override void Execute(object? parameter)
        {
            _entityStore.Entity = null;
            _viewModel.RenavigationCommand.Execute(null);
        }
    }
}
