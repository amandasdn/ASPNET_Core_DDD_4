﻿using Microsoft.EntityFrameworkCore;
using Project.Domain.Models;
using Project.Infrastructure.Data;
using Project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    public class CategoryRepository : IBaseCrud<Category>
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Category> SaveAsync(Category obj)
        {
            await _context.Categories.AddAsync(obj);

            await _context.SaveChangesAsync();

            return await FindByIdAsync(obj.Id);
        }

        public async Task UpdateAsync(Category obj)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(item => item.Id == obj.Id);

            if (category != null)
            {
                _context.Entry(category).CurrentValues.SetValues(obj);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListAllAsync()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();

            return categories.Where(item => !item.Removed).ToList();
        }

        public async Task<Category> FindByIdAsync(Guid id)
        {
            var category = await _context.Categories.AsNoTracking().Where(item => !item.Removed).FirstOrDefaultAsync(item => item.Id == id);

            return category;
        }
    }
}
