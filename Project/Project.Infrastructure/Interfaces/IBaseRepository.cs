using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> SaveAsync(T obj);

        Task UpdateAsync(T obj);

        Task RemoveAsync(T obj);

        Task<List<T>> ListAllAsync();

        Task<T> FindByIdAsync(Guid id);
    }
}
