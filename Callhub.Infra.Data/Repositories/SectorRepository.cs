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
    public class SectorRepository : IRepository<Sector>, ISectorRepository
    {
        public SectorRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        public readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task InsertAsync(Sector Model)
        {
            throw new NotImplementedException();
        }

        public Task<Sector> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sector>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sector> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Sector Model)
        {
            throw new NotImplementedException();
        }
    }
}
