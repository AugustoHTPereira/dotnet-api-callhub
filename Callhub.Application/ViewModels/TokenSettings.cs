using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Application.ViewModels
{
    public class TokenSettings
    {
        public string PrivateKey { get; set; }
        public string Issure { get; set; }
        public int ExpirationDays { get; set; }
    }
}
