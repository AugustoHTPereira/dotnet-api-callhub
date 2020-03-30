using Callhub.Application.Interfaces;
using Callhub.Application.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Callhub.Application.Services
{
    public class MailService : IMailService
    {
        public MailService(IOptions<MailSettings> mailSettings)
        {
            this._mailSettings = mailSettings.Value;
            this.From = new MailAddress(this._mailSettings.DefaultMail, this._mailSettings.UserName);
        }

        private readonly MailSettings _mailSettings;

        private IList<MailAddress> InCopies { get; set; }
        public void AddInCopy(string Mail)
        {
            this.InCopies.Add(new MailAddress(Mail));
        }

        private IList<MailAddress> To { get; set; }
        public void SetTo(string Email, string Name = "")
        {
            To.Add(new MailAddress(Email, Name));
        }

        private string Subject { get; set; } = "Callhub";
        public void SetSubject(string Subject)
        {
            this.Subject = "Callhub - " + Subject;
        }

        private MailAddress From { get; set; }
        public void SetFrom(string Email, string Name = "Callhub")
        {
            this.From = new MailAddress(Email, Name);
        }

        public async Task SendMessageAsync(string Message, string To)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(this._mailSettings.DefaultMail, "Callhub");
                mailMessage.To.Add(To);

                if (this.To != null)
                    foreach (MailAddress item in this.To)
                        mailMessage.To.Add(item);

                if (this.InCopies != null)
                    foreach (MailAddress item in InCopies)
                        mailMessage.CC.Add(item);

                mailMessage.Subject = this.Subject;
                mailMessage.Body = Message;
                mailMessage.IsBodyHtml = false;
                mailMessage.Priority = MailPriority.Normal;

                using (SmtpClient smtpClient = new SmtpClient(this._mailSettings.Domain, int.Parse(this._mailSettings.Port)))
                {
                    smtpClient.Credentials = new NetworkCredential(this._mailSettings.UserName, this._mailSettings.Password);
                    smtpClient.EnableSsl = true;
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
