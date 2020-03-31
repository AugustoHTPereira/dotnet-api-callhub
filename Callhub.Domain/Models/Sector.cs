using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Domain.Models
{
    public class Sector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
