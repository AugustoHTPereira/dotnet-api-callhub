using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Infra.Data.Repositories
{
    public class CallTypeRepository : IRepository<CallType>, ICallTypeRepository
    {
        public CallTypeRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        public readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task InsertAsync(CallType Model)
        {
            throw new NotImplementedException();
        }

        public Task<CallType> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CallType>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CallType> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CallType Model)
        {
            throw new NotImplementedException();
        }
    }
}
