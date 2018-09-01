using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

namespace Chama.Email
{
    public class SendEmail
    {
        private readonly ILogger _logger;

        public void SendEmailMessage(Domain.Models.Email.Email email)
        {
            try
            {
                var emailMessage = new MailMessage(email.To, email.From, email.Subject, email.Body);
                //EX: using GMAIL
                var client = new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true };
                var cred = new NetworkCredential("contact@projectchama.com", "projectchama123");
                client.Credentials = cred;
                client.UseDefaultCredentials = true;
                client.Send(emailMessage);
            }
            catch (Exception e)
            {
                _logger.LogError($"The exception {e.InnerException} occured to send email to {email.To}");
            }
        }
    }
}
