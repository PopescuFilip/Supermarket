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
    public class CategoryService
    {
        private readonly SupermarketDBContextFactory _dbContextFactory;
        public CategoryService(SupermarketDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public List<Category> GetAllCategories() 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Categories.FromSqlRaw("GetAllCategories")
                                         .ToList();
            }
        }
        public void CreateCategory(Category category) 
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("CreateCategory @p0, @p1", parameters: [category.Name, category.IsActive]); 
            }
        }
    }
}
