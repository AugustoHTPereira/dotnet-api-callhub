using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using Dapper;

namespace Callhub.Infra.Data.Repositories
{
  public class RoleRepository : IRepository<Role>, IRoleRepository
  {
    public RoleRepository(IConnection connection)
    {
      this._connection = connection.Connect();
    }

    private readonly IDbConnection _connection;

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public Task InsertAsync(Role Model)
    {
      throw new NotImplementedException();
    }

    public async Task<Role> SelectAsync(Guid Id)
    {
      return await this._connection.QueryFirstAsync<Role>("SELECT TOP 1 * FROM Roles WHERE Id = @Id", new { Id });
    }

    public Task<IEnumerable<Role>> SelectAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Role> SelectIdentityAsync()
    {
      throw new NotImplementedException();
    }

    public Task UpdateAsync(Role Model)
    {
      throw new NotImplementedException();
    }
  }
}