using Callhub.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Callhub.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyViewModel>> Select();
    }
}
