using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {

        Task<T> SaveAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetAsync(int id);
    }
}
