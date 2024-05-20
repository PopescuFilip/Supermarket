using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Stores
{
    public class SupplierStore
    {
        private Supplier? _supplier;
        public Supplier? Supplier
        { 
            get { return _supplier; } 
            set { _supplier = value; }
        }
    }
}
