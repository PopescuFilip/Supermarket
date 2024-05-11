using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class ReceiptItem
    {
        [Key]
        public int Id { get; set; }
        public required int Quantity { get; set; }
        public required Stock Item { get; set; } = null!;
        public required Receipt Receipt { get; set; } = null!;
        public float Subtotal => Quantity * Item.SellPrice;
    }
}
