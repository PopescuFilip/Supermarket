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
    public class ReceiptItemService : EntityService<ReceiptItem>
    {
        public ReceiptItemService(SupermarketDBContextFactory dBContextFactory) : base(dBContextFactory)
        {
        }

        public override IEnumerable<ReceiptItem> GetAll()
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                return context
                    .Set<ReceiptItem>()
                    .Include(x => x.Item)
                    .Include(x => x.Item.Product)
                    .ToList();
            }
        }
    }
}
