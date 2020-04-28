using Callhub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Interfaces
{
    public interface IAttachService
    {
        Task InsertAsync(AttachViewModel viewModel);
    }
}
