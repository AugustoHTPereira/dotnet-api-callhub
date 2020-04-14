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
      ICallTimelineRepository callTimelineRepository
    )
    {
      this._callRepository = callRepository;
      this._mapper = mapper;
      this._callTimelineRepository = callTimelineRepository;
    }

    private readonly ICallRepository _callRepository;
    private readonly IMapper _mapper;
    private readonly ICallTimelineRepository _callTimelineRepository;

    public async Task<IEnumerable<CallViewModel>> SelectAllByOwner(Guid UserId)
    {
      return this._mapper.Map<IEnumerable<Call>, IEnumerable<CallViewModel>>(await this._callRepository.SelectAllByOwner(UserId));
    }

    public async Task InsertAsync(CallViewModel Call)
    {
      await this._callRepository.InsertAsync(this._mapper.Map<CallViewModel, Call>(Call));
    }

    public async Task<CallViewModel> SelectAsync(Guid CallId)
    {
      CallViewModel Call = this._mapper.Map<CallViewModel>(await this._callRepository.SelectAsync(CallId));
      Call.Timeline = this._mapper.Map<IEnumerable<CallTimelineViewModel>>(await this._callTimelineRepository.SelectAllByCallIdAsync(CallId));
      return Call;
    }
  }
}
