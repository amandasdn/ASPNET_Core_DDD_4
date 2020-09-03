using Microsoft.EntityFrameworkCore;
using Project.Domain.Interfaces;
using Project.Domain.Models;
using Project.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    public class ProductRepository : IBaseCrud<Product>
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Product> SaveAsync(Product obj)
        {
            await _context.Products.AddAsync(obj);

            await _context.SaveChangesAsync();

            return await FindByIdAsync(obj.Id);
        }

        public async Task UpdateAsync(Product obj)
        {
            var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == obj.Id);

            if (product != null)
            {
                _context.Entry(product).CurrentValues.SetValues(obj);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> ListAllAsync()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            return products.Where(item => !item.Removed).ToList();
        }

        public async Task<Product> FindByIdAsync(Guid id)
        {
            var product = await _context.Products.AsNoTracking().Where(item => !item.Removed).FirstOrDefaultAsync(item => item.Id == id);

            return product;
        }
    }
}
