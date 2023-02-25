using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IAsyncManager<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
        Task<T> AddAsync(T item);
        Task DeleteAsync(T item);
        Task<T> UpdateAsync(T item);

    }
}
