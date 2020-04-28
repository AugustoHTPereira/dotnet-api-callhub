using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Infra.Data.Repositories
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        public UserRepository(IConnection connection)
        {
            this._connection = connection.Connect();
        }

        private readonly IDbConnection _connection;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task InsertAsync(User Model)
        {
            await this._connection.QueryAsync<User>($"INSERT INTO Users (Name, Surname, Email, PasswordHash) VALUES (@Name, @Surname, @Email, @Password)", Model);
        }

        public Task<User> SelectAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> SelectAsync()
        {
            return await this._connection.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task<User> SelectAsync(Guid Id)
        {
            return await this._connection.QueryFirstOrDefaultAsync<User>(@"SELECT * FROM Users WHERE Id = @Id", new { Id });
        }

        public async Task<User> SelectIdentityAsync()
        {
            return await this._connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users ORDER BY CreatedAt DESC");
        }

        public async Task UpdateAsync(User Model)
        {
            await this._connection.ExecuteAsync($"UPDATE Users SET Name = @Name, Surname = @Surname, DepartmentId = @DepartmentId WHERE Id = @Id", Model);
        }

        public async Task<User> SelectByCredentialsAsync(string Email, string PasswordHash)
        {
            return await this._connection.QueryFirstOrDefaultAsync<User>(@"SELECT * FROM Users WHERE Email = @Email AND PasswordHash = @PasswordHash", new { Email, PasswordHash });
        }
    }
}
