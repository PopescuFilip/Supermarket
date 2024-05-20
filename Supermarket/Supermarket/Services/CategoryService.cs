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
    public class CategoryService : IEntityService<Category>
    {
        private readonly SupermarketDBContextFactory _dbContextFactory;
        public CategoryService(SupermarketDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public IEnumerable<Category> GetAll() 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Categories.FromSqlRaw("GetAllCategories")
                                         .ToList();
            }
        }
        public void Create(Category category) 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("CreateCategory @p0, @p1", parameters: [category.Name, category.IsActive]); 
            }
        }
        public void Update(Category category) 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("UpdateCategory @p0, @p1", parameters: [category.Name, category.Id]);
            }
        }
        public void Delete(Category category) 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("DeleteCategory @p0", parameters: [category.Id]);

            }
        }
    }
}
