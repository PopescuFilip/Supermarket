using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Category : Entity
    {
        public required string Name { get; set; }
        public ICollection<Product> Products { get; } = [];
    }
}
