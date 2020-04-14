using System;

namespace Callhub.Application.ViewModels
{
  public class CallTimelineViewModel
  {
    public Guid Id { get; set; }
    public Guid CallId { get; set; }
    public string Message { get; set; }
    public string Observation { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual CallViewModel Call { get; set; }
    public virtual UserViewModel User { get; set; }
  }
}