using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.DB
{
    public class SupermarketDBContextFactory : IDesignTimeDbContextFactory<SupermarketDBContext>
    {
        const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=SupermarketDb;Trusted_Connection=True;";
        public SupermarketDBContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<SupermarketDBContext>();
            options.UseSqlServer(CONNECTION_STRING);

            return new SupermarketDBContext(options.Options);
        }
    }
}
