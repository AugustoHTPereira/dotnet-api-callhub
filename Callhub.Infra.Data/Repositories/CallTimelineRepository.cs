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
  public class CallTimelineRepository : IRepository<CallTimeline>, ICallTimelineRepository
  {
    public CallTimelineRepository(IConnection connection)
    {
      this._connection = connection.Connect();
    }

    private readonly IDbConnection _connection;

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public async Task InsertAsync(CallTimeline Model)
    {
      await this._connection.ExecuteAsync(@"INSERT INTO CallTimeline (CallId, Message, Observation) VALUES (@CallId, @Message, @Observation)", Model);
    }

    public Task UpdateAsync(CallTimeline Model)
    {
      throw new NotImplementedException();
    }

    public Task<CallTimeline> SelectAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CallTimeline>> SelectAsync()
    {
      throw new NotImplementedException();
    }

    public Task<CallTimeline> SelectIdentityAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<CallTimeline>> SelectAllByCallIdAsync(Guid CallId)
    {
      return await this._connection.QueryAsync<CallTimeline>("SELECT * FROM CallTimeline WHERE CallId = @CallId", new { CallId });
    }
  }
}