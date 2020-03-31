using Callhub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentViewModel>> SelectAllByCompanyAsync(Guid CompanyId);
        Task<DepartmentViewModel> Select(Guid Id);
        Task<IEnumerable<DepartmentViewModel>> Select();
    }
}
