using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> ListAllAsync();

        Task<T> FindByIdAsync(Guid id);

        Task<T> SaveAsync(T obj);

        Task RemoveAsync(T obj);
    }
}
