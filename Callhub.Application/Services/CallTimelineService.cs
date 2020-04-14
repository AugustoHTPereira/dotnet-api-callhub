using System.Threading.Tasks;
using AutoMapper;
using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Callhub.Domain.Interfaces.Repository;
using Callhub.Domain.Models;

namespace Callhub.Application.Services
{
  public class CallTimelineService : ICallTimelineService
  {
    public CallTimelineService(IMapper mapper, ICallTimelineRepository callTimelineRepository)
    {
      this._mapper = mapper;
      this._callTimelineRepository = callTimelineRepository;
    }

    private readonly IMapper _mapper;
    private readonly ICallTimelineRepository _callTimelineRepository;

    public async Task InsertAsync(CallTimelineViewModel callTimeLine)
    {
      await this._callTimelineRepository.InsertAsync(this._mapper.Map<CallTimeline>(callTimeLine));
    }
  }
}