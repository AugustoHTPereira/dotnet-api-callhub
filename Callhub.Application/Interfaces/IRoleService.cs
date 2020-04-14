using System.Threading.Tasks;
using Callhub.Application.ViewModels;
using System;

namespace Callhub.Application.Interfaces
{
  public interface IRoleService
  {
    Task<RoleViewModel> SelectAsync(Guid RoleId);
  }
}
