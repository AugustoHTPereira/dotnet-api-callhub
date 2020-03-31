using Callhub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> SelectAsync();
        Task<UserViewModel> CreateAsync(RegisterViewModel Data);
        Task UpdateAsync(UserViewModel Data);
        Task<UserViewModel> SelectAsync(Guid Id);

    }
}
