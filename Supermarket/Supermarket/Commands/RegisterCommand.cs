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
using System.Windows;

namespace Supermarket.Commands
{
    class RegisterCommand : CommandBase
    {
        private readonly LoginViewModel _loginVM;
        private readonly AuthenticationService _authenticationService;

        public RegisterCommand(LoginViewModel loginVM, 
            AuthenticationService authenticationService)
        {
            _loginVM = loginVM;
            _authenticationService = authenticationService;
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
            _authenticationService.Register(_loginVM.Username, _loginVM.Password);
            MessageBox.Show("registered");
        }
        public override bool CanExecute(object? parameter)
        {
            return _loginVM.AllRequiredFieldsCompleted() &&
                   base.CanExecute(parameter);
        }
    }
}
