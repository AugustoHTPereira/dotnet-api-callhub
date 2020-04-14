using System.Threading.Tasks;
using Callhub.Application.ViewModels;
using System.Collections.Generic;
using System;

namespace Callhub.Application.Interfaces
{
    public interface ICallService
    {
        Task<IEnumerable<CallViewModel>> SelectAllByOwner(Guid UserId);
        Task<CallViewModel> SelectAsync(Guid CallId);
        Task InsertAsync(CallViewModel Call);
    }
}
