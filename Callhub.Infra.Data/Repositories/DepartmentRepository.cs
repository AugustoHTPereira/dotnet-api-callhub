using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using Dapper;

namespace Callhub.Infra.Data.Repositories
{
    public class DepartmentRepository : IRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        private readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task InsertAsync(Department Model)
        {
            throw new NotImplementedException();
        }

        public Task<Department> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> SelectAsync()
        {
            return await this._connection.QueryAsync<Department>("SELECT * FROM Departments");
        }

        public Task<Department> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Department Model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> SelectAllByCompanyAsync(Guid CompanyId)
        {
            return await this._connection.QueryAsync<Department>(@"SELECT * FROM Departments WHERE CompanyId = @CompanyId", new { CompanyId });
        }
    }
}
