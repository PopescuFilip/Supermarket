using Microsoft.EntityFrameworkCore;
using Supermarket.DB;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class UserService
    {
        private readonly SupermarketDBContextFactory _dBContextFactory;
        public UserService(SupermarketDBContextFactory dbContextFactory)
        {
            _dBContextFactory = dbContextFactory;
        }
        public void AddUser(User user)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                context.Database
                    .ExecuteSqlRaw("CreateUser @p0, @p1, @p2, @p3",
                    parameters: [user.Name, user.Password, User.ToString(user.UserType), user.IsActive]);
            }
        }

        public User? Authenticate(string name, string password)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                var users = context.Users.
                    FromSqlRaw("AuthenticateUser @p0, @p1",
                    parameters: [name, password]).ToList();
                if (users.Count == 0)
                    return null;
                return users[0];
            }
        }
        public bool UserWithNameExists(string name)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                var users = context.Users.
                    FromSqlRaw("GetAllByName @p0",
                    parameters: [name]).ToList();

                if (users.Count == 0)
                    return false;
                return true;
            }
        }
    }
}
