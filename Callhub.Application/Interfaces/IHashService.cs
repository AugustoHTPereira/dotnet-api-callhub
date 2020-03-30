using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Application.Interfaces
{
    public interface IHashService
    {
        string Encode(string Value);
        string Decode(string Value);
    }
}
