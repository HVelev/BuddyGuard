using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace BuddyGuard.Core.Services
{
    public class MailService
    {
        public void SendConfirmationEmail(string recipient)
        {
            MailAddress to = new MailAddress(recipient);
            MailAddress from = new MailAddress("buddyguardapp@outlook.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Hello";
            message.Body = "Hello";
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("buddyguardapp@outlook.com", "buddyguard123"),
                EnableSsl = true
            };
            // code in brackets above needed if authentication required
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
