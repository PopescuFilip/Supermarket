using Checkers.Commands;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Services;
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
        private readonly NavigationService _navigationService;

        public LoginCommand(LoginViewModel loginVM, NavigationService navigationService) 
        {
            _loginVM = loginVM;
            _navigationService = navigationService;
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
            MessageBox.Show("works");
            _loginVM.ClearFields();
            _navigationService.Navigate(ViewType.Login);
        }
        public override bool CanExecute(object? parameter)
        {
            return _loginVM.AllRequiredFieldsCompleted() &&
                   base.CanExecute(parameter);
        }
    }
}
