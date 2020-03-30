using Callhub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Domain.Interfaces.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> SelectAllByCompanyAsync(Guid CompanyId);   
    }
}
