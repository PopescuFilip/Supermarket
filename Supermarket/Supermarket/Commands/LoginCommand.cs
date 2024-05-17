using Checkers.Commands;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Services;
using Supermarket.Stores;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Commands
{
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginVM;
        private readonly AuthenticationService _authenticationService;
        private readonly NavigationService<AdminOptionsViewModel> _navigationService;
        public LoginCommand(LoginViewModel loginVM, 
            AuthenticationService authenticationService,
            NavigationService<AdminOptionsViewModel> adminNavigationService) 
        {
            _loginVM = loginVM;
            _authenticationService = authenticationService;
            _navigationService = adminNavigationService;
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
            if (_authenticationService.Login(_loginVM.Username, _loginVM.Password))
                _navigationService.Navigate();
            else
                MessageBox.Show("Incorrect username or password");
        }
        public override bool CanExecute(object? parameter)
        {
            return _loginVM.AllRequiredFieldsCompleted() &&
                   base.CanExecute(parameter);
        }
    }
}
