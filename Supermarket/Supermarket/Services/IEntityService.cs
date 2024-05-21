using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public interface IEntityService<T> where T : Entity
    {
        public IEnumerable<T> GetAll();
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
