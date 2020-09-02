using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces
{
    public interface IBaseCrud<T>
    {
        Task<T> SaveAsync(T obj);

        Task UpdateAsync(T obj);

        Task<List<T>> ListAllAsync();

        Task<T> FindByIdAsync(Guid id);
    }
}
