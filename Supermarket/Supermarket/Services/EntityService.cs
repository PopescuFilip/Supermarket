using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Supermarket.DB;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected readonly SupermarketDBContextFactory _dBContextFactory;

        public EntityService(SupermarketDBContextFactory dBContextFactory) 
        {
            _dBContextFactory = dBContextFactory;
        }
        public void Create(T entity)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = _dBContextFactory.CreateDbContext())
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
