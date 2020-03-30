using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Infra.Data.Repositories
{
    public class CompanyRepository : IRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        private readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task InsertAsync(Company Model)
        {
            throw new NotImplementedException();
        }

        public Task<Company> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> SelectAsync()
        {
            return await this._connection.QueryAsync<Company>("SELECT * FROM Companies");
        }

        public Task<Company> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company Model)
        {
            throw new NotImplementedException();
        }
    }
}
