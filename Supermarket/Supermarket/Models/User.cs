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
    public class User : Entity
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required UserType UserType { get; set; }
        public ICollection<Receipt> Receipts { get; } = [];
        public static string ToString(UserType type)
        {
            return type switch
            {
                UserType.Admin => "Admin",
                UserType.Cashier => "Cashier",
                _ => string.Empty,
            };
        }
        public static UserType ToEnum(string userType)
        {
            return userType switch
            {
                ("Admin") => UserType.Admin,
                ("Cashier") => UserType.Cashier,
                _ => throw new ArgumentException($"{userType} is not a valid string"),
            };
            ;
        }

    }
}
