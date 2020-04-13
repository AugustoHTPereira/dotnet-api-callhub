using System;

namespace Callhub.Domain.Models
{
  public class Attach
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public string Url { get; set; }
  }
}