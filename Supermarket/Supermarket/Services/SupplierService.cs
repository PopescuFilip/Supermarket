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
    public class SupplierService
    {
        private readonly SupermarketDBContextFactory _dbContextFactory;
        public SupplierService(SupermarketDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public List<Supplier> GetAllSuppliers()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Suppliers.FromSqlRaw("GetAllSuppliers")
                                         .ToList();
            }
        }
        public void CreateSupplier(Supplier supplier)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("CreateSupplier @p0, @p1", 
                    parameters: [supplier.Name, supplier.CountryOfOrigin, supplier.IsActive]);
            }
        }
        public void UpdateSupplier(Supplier supplier)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("UpdateSupplier @p0, @p1, @p2", 
                    parameters: [supplier.Name, supplier.CountryOfOrigin, supplier.Id]);
            }
        }
        public void DeleteSupplier(Supplier supplier)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("DeleteSupplier @p0", parameters: [supplier.Id]);

            }
        }
    }
}
