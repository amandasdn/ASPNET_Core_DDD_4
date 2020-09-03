using Project.Domain.Models;
using Project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Infrastructure.Repositories;

namespace Project.Service.Services
{
    public class CategoryService : IBaseCrud<Category>
    {
        private readonly CategoryRepository _repo;

        public CategoryService(CategoryRepository repo) => _repo = repo;

        public async Task<Category> FindByIdAsync(Guid id) => await _repo.FindByIdAsync(id);

        public async Task<IEnumerable<Category>> ListAllAsync() => await _repo.ListAllAsync();

        public async Task UpdateAsync(Category obj) => await _repo.UpdateAsync(obj);

        public async Task RemoveAsync(Category obj)
        {
            obj.Removed = true;

            await _repo.UpdateAsync(obj);
        }

        public async Task<Category> SaveAsync(Category obj) => await _repo.SaveAsync(obj);
    }
}
