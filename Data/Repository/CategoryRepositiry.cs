using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repository
{
    public class CategoryRepositiry: ICarsCategory
    {
        private readonly ShopDbContext addDbContext;

        public CategoryRepositiry(ShopDbContext addDbContext)
        {
            this.addDbContext = addDbContext ?? throw new ArgumentNullException(nameof(addDbContext));
        }
        public IEnumerable<Category> GetCategories => addDbContext.Categories.Include(c=>c.Name);
    }
}
