using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Stock : Entity
    {
        [Range(0, int.MaxValue)]
        public required int Quantity { get; set; }
        public required DateOnly ExpirationDate { get; set; }
        public required float BuyPrice { get; set; }
        public required float SellPrice { get; set; }
        public required Product Product { get; set; } = null!;
        public ICollection<ReceiptItem> Items { get; } = [];
        public bool IsActive { get; set; }

        public Stock()
        {
            IsActive = true;
        }
    }
}
