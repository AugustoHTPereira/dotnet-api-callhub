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
    public class CallRespository : IRepository<Call>, ICallRepository
    {
        public CallRespository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        public readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task InsertAsync(Call Model)
        {
            throw new NotImplementedException();
        }

        public Task<Call> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Call>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Call> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Call Model)
        {
            throw new NotImplementedException();
        }
    }
}
