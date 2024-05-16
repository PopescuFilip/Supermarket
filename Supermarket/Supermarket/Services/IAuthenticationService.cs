using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public interface IAuthenticationService
    {
        public bool Login(string username, string password);
        public void Register(User user);
    }
}
