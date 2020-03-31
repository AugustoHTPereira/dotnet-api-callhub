using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Interfaces
{
    public interface IMailService
    {
        Task SendMessageAsync(string Message, string To);

        void SetTo(string Email, string Name);
        void SetSubject(string Subject);
        void SetFrom(string Email, string Name);
        void AddInCopy(string Email);
    }
}
