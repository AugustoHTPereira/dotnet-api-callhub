using Callhub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Domain.Models
{
    public class Call
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid UserId { get; set; }
        public Guid SectorDestinId { get; set; }
        public Priority Priority { get; set; }
        public int PriorityOrder { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid CallCategoryId { get; set; }
        public Guid CallTypeId { get; set; }
        public int ResolutionNote { get; set; }
        public string NoteObservation { get; set; }

        public virtual CallCategory CallCategory { get; set; }
        public virtual CallType CallType { get; set; }
        public virtual Sector SectorDestin { get; set; }
        public virtual User User { get; set; }
    }
}
