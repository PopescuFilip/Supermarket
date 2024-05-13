using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Receipt : Entity
    {
        public DateOnly Date { get; init; }
        public required User Cashier { get; set; } = null!;
        public ICollection<ReceiptItem> Items { get; } = [];
        public float Total => Items.Sum(x => x.Subtotal);

        public Receipt()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
