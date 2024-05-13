using Checkers.ViewModels;
using Supermarket.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
		private string? _username;
		public string? Username
		{
			get { return _username; }
			set { _username = value;  OnPropertyChanged(nameof(Username));  }
		}

        private string? _password;
        public string? Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }
        public bool AllRequiredFieldsCompleted()
        {
            return !String.IsNullOrEmpty(Username) &&
                   !String.IsNullOrEmpty(Password);
        }
    }
}
