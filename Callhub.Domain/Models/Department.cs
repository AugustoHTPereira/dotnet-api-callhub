using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Domain.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
