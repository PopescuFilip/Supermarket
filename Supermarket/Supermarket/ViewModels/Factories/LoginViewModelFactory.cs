using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels.Factories
{
    public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly AuthenticationService _authenticationService;
        public LoginViewModelFactory(AuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticationService);
        }
    }
}
