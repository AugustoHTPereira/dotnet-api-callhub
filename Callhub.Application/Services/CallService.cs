using AutoMapper;
using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Services
{
  public class CallService : ICallService
  {
    public CallService(
      ICallRepository callRepository,
      IMapper mapper,
      ICategoryRespository categoryRespository
    )
    {
      this._callRepository = callRepository;
      this._mapper = mapper;
    }

    private readonly ICallRepository _callRepository;
    private readonly IMapper _mapper;

    public async Task<IEnumerable<CallViewModel>> SelectAllByOwner(Guid UserId)
    {
      return this._mapper.Map<IEnumerable<Call>, IEnumerable<CallViewModel>>(await this._callRepository.SelectAllByOwner(UserId));
    }

    public async Task InsertAsync(CallViewModel Call)
    {
      await this._callRepository.InsertAsync(this._mapper.Map<CallViewModel, Call>(Call));
    }
  }
}
