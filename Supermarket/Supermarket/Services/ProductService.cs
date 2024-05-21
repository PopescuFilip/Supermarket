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
    public class ProductService : EntityService<Product>
    {
        public ProductService(SupermarketDBContextFactory dBContextFactory) : 
            base(dBContextFactory)
        {
        }
        public override void Create(Product entity)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                entity.Category = context.Categories.Single(c => c.Id == entity.Category.Id);
                entity.Supplier = context.Suppliers.Single(c => c.Id == entity.Supplier.Id);
                context.Set<Product>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
