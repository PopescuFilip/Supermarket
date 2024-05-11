using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public enum UserType
    {
        Admin,
        Cashier
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required UserType UserType { get; set; }
        public ICollection<Receipt> Receipts { get; } = [];

    }
}
