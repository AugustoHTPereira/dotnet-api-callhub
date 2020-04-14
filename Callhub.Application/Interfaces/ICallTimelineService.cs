using System.Threading.Tasks;
using Callhub.Application.ViewModels;

namespace Callhub.Application.Interfaces
{
  public interface ICallTimelineService
  {
    Task InsertAsync(CallTimelineViewModel callTimeLine);
  }
}