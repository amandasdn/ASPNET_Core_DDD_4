using Project.Domain.Models;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Infrastructure.Repositories;

namespace Project.Service.Services
{
    public class CategoriesService : IBaseServices<Category>
    {
        private readonly CategoryRepository _repo;

        public CategoriesService(CategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Category> FindByIdAsync(Guid id) => await _repo.FindByIdAsync(id);

        public async Task<List<Category>> ListAllAsync() => await _repo.ListAllAsync();

        public async Task RemoveAsync(Category obj) => await _repo.RemoveAsync(obj);

        public async Task<Category> SaveAsync(Category obj) => await _repo.SaveAsync(obj);
    }
}
