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
        private readonly DatabaseService _databaseService;
        public User? ConnectedUser { get; set; }
        
        public AuthenticationService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public bool Login(string username, string password)
        {
            ConnectedUser = _databaseService.Authenticate(username, password);
            if (ConnectedUser != null)
                 return true;
            return false;
        }

        public bool Register(string username, string password) 
        {
            if (_databaseService.UserWithNameExists(username))
                return false;

            ConnectedUser = new User()
            {
                Name = username,
                Password = password,
                UserType = UserType.Cashier
            };
            _databaseService.AddUser(ConnectedUser);
            return true;
        }
    }
}
