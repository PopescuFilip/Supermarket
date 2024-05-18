using Microsoft.EntityFrameworkCore;
using Supermarket.DB;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Services
{
    public class ProductService
    {
        private readonly SupermarketDBContextFactory _dBContextFactory;
        public ProductService(SupermarketDBContextFactory dBContextFactory)
        {
            _dBContextFactory = dBContextFactory;
        }
        
    }
}
