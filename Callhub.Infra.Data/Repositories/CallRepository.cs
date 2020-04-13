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

    public async Task InsertAsync(Call Model)
    {
      await this._connection.ExecuteAsync(@"INSERT INTO Calls (Title, Description, Priority, SectorDestinId, ServiceLevel, UserId) 
                                            VALUES (@Title, @Description, @Priority, @SectorDestinId, @ServiceLevel, @UserId)", Model);
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

    public async Task<IEnumerable<Call>> SelectAllByOwner(Guid UserId)
    {
      return await this._connection.QueryAsync<Call>(@" SELECT  Calls.Id, 
                                                            Calls.Title, 
                                                            Calls.[Description], 
                                                            Calls.Priority, 
                                                            Calls.Situation, 
                                                            Calls.SectorDestinId,
                                                            Calls.CategoryId,
                                                            Calls.CreatedAt
                                                        FROM Calls
                                                        LEFT JOIN Categories C ON C.Id = Calls.CategoryId
                                                        INNER JOIN Sectors S ON S.Id = Calls.SectorDestinId
                                                        WHERE Calls.UserId = @UserId", new { UserId });
    }
  }
}
