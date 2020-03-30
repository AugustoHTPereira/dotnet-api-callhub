using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Application.ViewModels
{
    public class MailSettings
    {
        public string Domain { get; set; }
        public string Port { get; set; }
        public string DefaultMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
