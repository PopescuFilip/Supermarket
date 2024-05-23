using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Product : DeleteableEntity
    {
        [StringLength(12, ErrorMessage = "barcode cannot exceed 12 characters")]
        public required string Barcode { get; set; }
        public required string Name { get; set; }
        public required Supplier Supplier { get; set; } = null!;
        public required Category Category { get; set; } = null!;
        public ICollection<Stock> Stocks { get; } = [];

        static public bool IsValidBarcode(string barcode)
        {
            return !String.IsNullOrEmpty(barcode) &&
                barcode.Length == 12 &&
                barcode.All(c => Char.IsDigit(c));
        }
    }
}
