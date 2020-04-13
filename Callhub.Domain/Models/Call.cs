using System;

namespace Callhub.Domain.Models
{
    public class Call
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Note { get; set; }
        public string NoteObservation { get; set; }
        public Guid UserId { get; set; }
        public Guid SectorDestinId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Category CallCategory { get; set; }
        public virtual Sector SectorDestin { get; set; }
        public virtual User User { get; set; }
    }
}
