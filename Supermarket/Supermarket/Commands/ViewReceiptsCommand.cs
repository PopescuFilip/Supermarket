using Supermarket.Models;
using Supermarket.Stores;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class ViewReceiptsCommand : CommandBase
    {
        private readonly UserViewModel _viewModel;
        private readonly EntityStore<User> _entityStore;

        public ViewReceiptsCommand(
            UserViewModel viewModel,
            EntityStore<User> entityStore) 
        {
            _viewModel = viewModel;
            _entityStore = entityStore;
        }
        public override void Execute(object? parameter)
        {
            _entityStore.Entity = _viewModel.Entity;
            _viewModel.ViewReceiptsNavigationCommand.Execute(null);
        }
        public override bool CanExecute(object? parameter)
        {
            return _viewModel.Entity.UserType == UserType.Cashier && 
                base.CanExecute(parameter);
        }
    }
}
