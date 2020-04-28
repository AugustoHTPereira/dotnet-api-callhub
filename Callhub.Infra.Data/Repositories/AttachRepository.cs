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
    public class AttachRepository : IAttachRepository
    {
        public AttachRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        private readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task InsertAsync(Attach Model)
        {
            await this._connection.ExecuteAsync(@"INSERT INTO Attachs (Name, Type, Size, FullPath, RelativePath, TableName, TableRegisterId)
                                                  VALUES (@Name, @Type, @Size, @FullPath, @RelativePath, @TableName, @TableRegisterId)", Model);
        }

        public Task UpdateAsync(Attach Model)
        {
            throw new NotImplementedException();
        }

        public Task<Attach> SelectAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attach>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Attach> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }
    }
}
