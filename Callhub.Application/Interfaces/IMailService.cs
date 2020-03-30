using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Interfaces
{
    public interface IMailService
    {
        Task SendMessageAsync(string Message, string To);
    }
}
