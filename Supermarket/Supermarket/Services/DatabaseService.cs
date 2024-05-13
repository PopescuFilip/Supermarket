using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Supermarket.DB;
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
        public void AddUser(string name, string password)
        {
            string type = "Cashier";
            using (var context = _dBContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("CreateUser @p0, @p1, @p2", parameters: [name, password, type]);
            }
        }
    }
}
