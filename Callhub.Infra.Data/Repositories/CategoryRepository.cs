using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Callhub.Infra.Data.Repositories
{
  public class CategoryRepository : IRepository<Category>, ICategoryRespository
  {
    public CategoryRepository(IConnection connection)
    {
      this._connection = connection.Connect();
    }

    public readonly IDbConnection _connection;

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public Task InsertAsync(Category Model)
    {
      throw new NotImplementedException();
    }

    public async Task<Category> SelectAsync(Guid Id)
    {
      return await this._connection.QueryFirstOrDefaultAsync(@"SELECT TOP 1 * FROM CATEGORIES WHERE ID = @Id", new { Id });
    }

    public Task<IEnumerable<Category>> SelectAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Category> SelectIdentityAsync()
    {
      throw new NotImplementedException();
    }

    public Task UpdateAsync(Category Model)
    {
      throw new NotImplementedException();
    }
  }
}
