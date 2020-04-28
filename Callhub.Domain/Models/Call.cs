using System;
using System.Collections.Generic;
using Callhub.Domain.Enums;

namespace Callhub.Domain.Models
{
    public class Call
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int ServiceLevel { get; set; }
        public int Note { get; set; }
        public string NoteObservation { get; set; }
        public Guid UserId { get; set; }
        public Guid SectorDestinId { get; set; }
        public Guid CategoryId { get; set; }
        public string Situation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Category Category { get; set; }
        public virtual Sector SectorDestin { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<Attach> Attachs { get; set; }
    }
}
