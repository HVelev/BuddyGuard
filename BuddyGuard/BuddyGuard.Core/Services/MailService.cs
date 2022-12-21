using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Constants;
using System.Net;
using System.Net.Mail;

namespace BuddyGuard.Core.Services
{
    public class MailService : IMailService
    {
        public async Task SendConfirmationEmail(string recipient)
        {
            string subject = DataConstants.MailConstants.ConfirmationSubject;
            string body = DataConstants.MailConstants.ConfirmationBody;
            MailMessage message = CreateMail(recipient, subject, body);

            SmtpClient client = GetClient();
            try
            {
                await client.SendMailAsync(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task SendRejectionEmail(string recipient)
        {
            string subject = DataConstants.MailConstants.RejectionSubject;
            string body = DataConstants.MailConstants.RejectionBody;

            var message = CreateMail(recipient, subject, body);

            var client = GetClient();
            try
            {
                await client.SendMailAsync(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public MailMessage CreateMail(string recipient, string subject, string body)
        {
            MailAddress from = new MailAddress(DataConstants.MailConstants.Email);
            MailAddress to = new MailAddress(recipient);

            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            message.Body = body;

            return message;
        }

        public SmtpClient GetClient()
        {
            SmtpClient client = new SmtpClient(DataConstants.MailConstants.SMTPServer, DataConstants.MailConstants.SMTPPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(DataConstants.MailConstants.Email, DataConstants.MailConstants.Password),
                EnableSsl = true
            };

            return client;
        }
    }
}
