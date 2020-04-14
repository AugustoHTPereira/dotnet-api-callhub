using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Callhub.Domain.Models;

namespace Callhub.Domain.Interfaces.Repository
{
  public interface ICallTimelineRepository : IRepository<CallTimeline>
  {
    Task<IEnumerable<CallTimeline>> SelectAllByCallIdAsync(Guid CallId);
  }
}