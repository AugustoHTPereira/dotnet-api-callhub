using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Domain.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual IEnumerable<Department> Departments { get; set; }
    }
}
