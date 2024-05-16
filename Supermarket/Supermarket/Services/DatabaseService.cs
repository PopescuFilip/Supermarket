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
    public class DatabaseService
    {
        private readonly SupermarketDBContextFactory _dBContextFactory;
        public DatabaseService(SupermarketDBContextFactory dbContextFactory)
        {
            _dBContextFactory = dbContextFactory;
        }
        public void AddUser(User user)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                context.Database
                    .ExecuteSqlRaw("CreateUser @p0, @p1, @p2", 
                    parameters: [user.Name, user.Password, User.ToString(user.UserType)]);
            }
        }

        public User? Authenticate(string name,  string password) 
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                var students = context.Users.
                    FromSqlRaw("AuthenticateUser @p0, @p1",
                    parameters: [name, password]).ToList();
                if(students.Count == 0)
                    return null;
                return students[0];
            }
        }
    }
}
