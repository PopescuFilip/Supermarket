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
    public class CreateReceiptCommand : CommandBase
    {
        private readonly CreateReceiptViewModel _viewModel;
        private readonly IEntityService<Receipt> _entityService;
        private readonly EntityStore<Receipt> _entityStore;

        public CreateReceiptCommand(
            CreateReceiptViewModel viewModel, 
            IEntityService<Receipt> entityService,
            EntityStore<Receipt> entityStore)
        {
            _viewModel = viewModel;
            _entityService = entityService;
            _entityStore = entityStore;
        }
        public override void Execute(object? parameter)
        {
            _entityService.Create(_viewModel.Receipt);
            _entityStore.Entity = null;
            _viewModel.RenavigationCommand.Execute(null);
        }
    }
}
