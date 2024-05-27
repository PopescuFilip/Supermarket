using Supermarket.DB;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class ReceiptService : EntityService<Receipt>
    {
        public ReceiptService(SupermarketDBContextFactory dBContextFactory) : 
            base(dBContextFactory)
        {
        }

        public override void Create(Receipt entity)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                foreach (var item in entity.Items) 
                {
                    item.Item = context.Stocks.Single(s => s.Id == item.Item.Id); 
                }
                entity.Cashier = context.Users.Single(u => u.Id == entity.Cashier.Id);
                context.Set<Receipt>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
