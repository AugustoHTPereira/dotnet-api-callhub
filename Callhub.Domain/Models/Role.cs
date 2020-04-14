using System;

namespace Callhub.Domain.Models
{
  public class Role
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}