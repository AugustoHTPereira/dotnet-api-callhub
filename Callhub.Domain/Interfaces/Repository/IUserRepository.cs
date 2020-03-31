using Callhub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> SelectByCredentialsAsync(string Email, string PasswordHash);
    }
}
