using System;

namespace Callhub.Domain.Models
{
  public class CallTimeline
  {
    public Guid Id { get; set; }
    public Guid CallId { get; set; }
    public string Message { get; set; }
    public string Observation { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Call Call { get; set; }
  }
}