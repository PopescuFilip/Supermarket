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
    class DatabaseService
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
    }
}
