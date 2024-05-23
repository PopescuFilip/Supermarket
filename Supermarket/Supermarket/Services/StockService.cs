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
    public class StockService : DeleteableEntityService<Stock>
    {
        public StockService(SupermarketDBContextFactory dBContextFactory) : 
            base(dBContextFactory)
        {
        }
        public override void Create(Stock entity)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                entity.Product = context.Products.Single(p => p.Id == entity.Product.Id);
                context.Set<Stock>().Add(entity);
                context.SaveChanges();
            }
        }
        public override IEnumerable<Stock> GetAll()
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                return context
                    .Set<Stock>()
                    .Where(x => x.IsActive == true)
                    .Include(x => x.Product)
                    .ToList();
            }
        }
    }
}
