using Supermarket.DB;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class DeleteableEntityService<T> : EntityService<T> where T : DeleteableEntity
    {
        public DeleteableEntityService(SupermarketDBContextFactory dBContextFactory) :
            base(dBContextFactory)
        {
        }
        public override void Delete(T entity)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                entity.IsActive = false;
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
        }

        public override IEnumerable<T> GetAll()
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                return context.Set<T>().Where(x => x.IsActive == true).ToList();
            }
        }
    }
}
