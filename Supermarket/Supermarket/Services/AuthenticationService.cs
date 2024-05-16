using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class AuthenticationService : IAuthenticationService
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

        public void Register(User user) 
        {
            ConnectedUser = user;
            _databaseService.AddUser(user);
        }
    }
}
