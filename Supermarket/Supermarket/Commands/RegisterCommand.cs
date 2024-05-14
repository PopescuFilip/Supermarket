using Checkers.Commands;
using Supermarket.Services;
using Supermarket.ViewModels;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    class RegisterCommand : CommandBase
    {
        private readonly LoginViewModel _loginVM;
        private readonly NavigationService _navigationService;
        private readonly DatabaseService _databaseService;
        public RegisterCommand(LoginViewModel loginVM, NavigationService navigationService)
        {
            _loginVM = loginVM;
            _navigationService = navigationService;
            _databaseService = new DatabaseService(new DB.SupermarketDBContextFactory());
            _loginVM.PropertyChanged += OnViewModelProperyChanged;
        }

        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Username) ||
                e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecutedChanged();
            }
        }
        public override void Execute(object? parameter)
        {
            _databaseService.AddUser(new User()
            {
                Name = _loginVM.Username,
                Password = _loginVM.Password,
                UserType = UserType.Cashier
            });
        }
        public override bool CanExecute(object? parameter)
        {
            return _loginVM.AllRequiredFieldsCompleted() &&
                   base.CanExecute(parameter);
        }
    }
}
