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
    public class UserEntityService : EntityService<User>
    {
        public UserEntityService(SupermarketDBContextFactory dBContextFactory) : base(dBContextFactory)
        {
        }

        public override IEnumerable<User> GetAll()
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                return context
                    .Set<User>()
                    .Where(x => x.IsActive == true)
                    .Include(x => x.Receipts)
                    .ToList();
            }
        }
    }
}
