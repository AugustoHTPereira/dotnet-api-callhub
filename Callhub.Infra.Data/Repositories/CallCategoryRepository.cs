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
    public class CallCategoryRepository : IRepository<CallCategory>, ICallCategoryRespository
    {
        public CallCategoryRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        public readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task InsertAsync(CallCategory Model)
        {
            throw new NotImplementedException();
        }

        public Task<CallCategory> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CallCategory>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CallCategory> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CallCategory Model)
        {
            throw new NotImplementedException();
        }
    }
}
