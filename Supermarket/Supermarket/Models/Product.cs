using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Title { get; set; }
    }
}
