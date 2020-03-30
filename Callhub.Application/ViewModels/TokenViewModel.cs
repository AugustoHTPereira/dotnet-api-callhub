using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Application.ViewModels
{
    public class TokenViewModel
    {
        public UserViewModel User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiressAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
