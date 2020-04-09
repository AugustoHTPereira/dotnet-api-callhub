using Callhub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Domain.Models
{
  public class User
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public Priority Priority { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid DepartmentId { get; set; }
    public Role Role { get; set; }

    public virtual Department Department { get; set; }
  }
}
