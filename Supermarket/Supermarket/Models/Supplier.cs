using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Supplier : DeleteableEntity
    {
        public required string Name { get; set; }
        public required string CountryOfOrigin { get; set; }
        public ICollection<Product> Products { get; } = [];
    }
}
