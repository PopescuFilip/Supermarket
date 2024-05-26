using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Stores
{
    public class EntityStore<T> where T : Entity
    {
        private T? _entity;
        public T? Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        private IEnumerable<T>? _entities;
        public IEnumerable<T>? Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }
    }
}
