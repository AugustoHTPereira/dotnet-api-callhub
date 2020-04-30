using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using Callhub.Infra.Data.Connection;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            await this._connection.QueryAsync<User>(@"INSERT INTO Users (Name, Surname, Email, Password) VALUES (@Name, @Surname, @Email, @Password)", Model);
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
            var results = await this._connection
                .QueryAsync<User,
                            Department,
                            Role,
                            Company,
                            User>(@"SELECT TOP 1
                                        U.Id, 
                                        U.Name, 
                                        U.Surname, 
                                        U.Email,
                                        D.Id,
                                        D.Name, 
                                        R.Id,
                                        R.Name,
                                        C.Id,
                                        C.Name
                                    FROM Users U
                                    LEFT JOIN Departments D on D.Id = U.DepartmentId
                                    LEFT JOIN Roles R on R.Id = U.RoleId
                                    LEFT JOIN Companies C on C.Id = D.CompanyId
                                    WHERE U.Id = @Id",
                                    map: (user, department, role, company) =>
                                    {
                                        user.Role = role;
                                        user.Department = department;
                                        user.Department.Company = company;
                                        return user;
                                    },
                                    param: new { Id }
                                );

            return results.AsList().FirstOrDefault();
        }

        public async Task<User> SelectIdentityAsync()
        {
            return await this._connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users ORDER BY CreatedAt DESC");
        }

        public async Task UpdateAsync(User Model)
        {
            await this._connection.ExecuteAsync(@"UPDATE Users SET Name = @Name, Surname = @Surname, DepartmentId = @DepartmentId WHERE Id = @Id", Model);
        }

        public async Task<User> SelectByCredentialsAsync(string Email, string PasswordHash)
        {
            var results = await this._connection
                .QueryAsync<User,
                            Role,
                            User>(@"SELECT 
                                      U.Id,
                                      U.Name,
                                      U.Surname,
                                      U.Email,
                                      U.Priority,
                                      u.DepartmentId,
                                      U.RoleId,
                                      U.CreatedAt,
                                      R.Id, 
                                      R.Name
                                    FROM Users U
                                    LEFT JOIN Roles R on R.id = U.RoleId 
                                    WHERE U.Email = @Email AND U.Password = @PasswordHash",
                                    map: (user, role) =>
                                    {
                                        user.Role = role;
                                        return user;
                                    }, new { Email, PasswordHash }
                                );

            return results.AsList().FirstOrDefault();
        }
    }
}
