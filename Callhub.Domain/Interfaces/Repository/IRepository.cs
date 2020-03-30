using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task InsertAsync(T Model);
        Task UpdateAsync(T Model);
        Task<T> SelectAsync(Guid Id);
        Task<IEnumerable<T>> SelectAsync();
        Task<T> SelectIdentityAsync();
    }
}
