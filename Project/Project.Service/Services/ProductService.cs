using Project.Domain.Interfaces;
using Project.Domain.Models;
using Project.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class ProductService : IBaseCrud<Product>
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo) => _repo = repo;

        public async Task<Product> FindByIdAsync(Guid id) => await _repo.FindByIdAsync(id);

        public async Task<IEnumerable<Product>> ListAllAsync() => await _repo.ListAllAsync();

        public async Task UpdateAsync(Product obj) => await _repo.UpdateAsync(obj);

        public async Task RemoveAsync(Product obj)
        {
            obj.Removed = true;

            await _repo.UpdateAsync(obj);
        }

        public async Task<Product> SaveAsync(Product obj) => await _repo.SaveAsync(obj);
    }
}
