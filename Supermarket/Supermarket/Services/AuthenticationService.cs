using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class AuthenticationService
    {
        private readonly UserService _userService;
        public User? ConnectedUser { get; set; }
        
        public AuthenticationService(UserService userService)
        {
            _userService = userService;
        }
        public bool Login(string username, string password)
        {
            ConnectedUser = _userService.Authenticate(username, password);
            if (ConnectedUser != null)
                 return true;
            return false;
        }

        public bool Register(string username, string password) 
        {
            if (_userService.UserWithNameExists(username))
                return false;

            ConnectedUser = new User()
            {
                Name = username,
                Password = password,
                UserType = UserType.Cashier
            };
            _userService.AddUser(ConnectedUser);
            return true;
        }
    }
}
