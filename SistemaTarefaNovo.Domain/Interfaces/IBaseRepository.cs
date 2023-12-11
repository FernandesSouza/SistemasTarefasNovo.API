using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task UpdateAsync (T entity);    

    }
}
