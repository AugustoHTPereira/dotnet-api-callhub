using Callhub.Domain.Enums;
using System;

namespace Callhub.Domain.Models
{
    public class CallCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
