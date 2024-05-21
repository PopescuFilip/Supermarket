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
    public class SupplierService : IEntityService<Supplier>
    {
        private readonly SupermarketDBContextFactory _dbContextFactory;
        public SupplierService(SupermarketDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IEnumerable<Supplier> GetAll()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Suppliers.FromSqlRaw("GetAllSuppliers")
                                         .ToList();
            }
        }
        public void Create(Supplier supplier)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("CreateSupplier @p0, @p1, @p2", 
                    parameters: [supplier.Name, supplier.CountryOfOrigin, supplier.IsActive]);
            }
        }
        public void Update(Supplier supplier)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("UpdateSupplier @p0, @p1, @p2", 
                    parameters: [supplier.Name, supplier.CountryOfOrigin, supplier.Id]);
            }
        }
        public void Delete(Supplier supplier)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("DeleteSupplier @p0", parameters: [supplier.Id]);

            }
        }
    }
}
