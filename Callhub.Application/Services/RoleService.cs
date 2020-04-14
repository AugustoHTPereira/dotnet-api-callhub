using System;
using System.Threading.Tasks;
using AutoMapper;
using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Callhub.Domain.Interfaces.Repository;

namespace Callhub.Application.Services
{
  public class RoleService : IRoleService
  {
    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
      this._roleRepository = roleRepository;
      this._mapper = mapper;
    }

    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public async Task<RoleViewModel> SelectAsync(Guid RoleId)
    {
      return this._mapper.Map<RoleViewModel>(await this._roleRepository.SelectAsync(RoleId));
    }
  }
}