using BuddyGuard.Core.Contracts;
using System.Net;
using System.Net.Mail;

namespace BuddyGuard.Core.Services
{
    public class MailService : IMailService
    {
        public async Task SendConfirmationEmail(string recipient)
        {
            string subject = "Одобрена заявка 🐶";
            string body = "Здравейте,\r\n\r\nВашата заявка е одобрена! Очаквайте служител да се свърже с Вас за потвърждаване на дата и час за среща. Благодарим, че избрахте BuddyGuard. \r\n\r\nПоздрави и до скоро!\r\n\r\nЗа допълнителни въпроси, моля свържете се с нас на този имейл или на телефон: +359877882390";
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
            string subject = "Отказана заявка 🐶";
            string body = "Здравейте,\r\n\r\nВашата заявка е отказана. В момента няма свободни гледачи, които да поемат грижите за домашния Ви любимец. Извиняваме се за причиненото неудобтсво!\r\n\r\nПоздрави,\r\nBuddyguard";

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
            MailAddress from = new MailAddress("buddyguardapp@outlook.com");
            MailAddress to = new MailAddress(recipient);

            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            message.Body = body;

            return message;
        }

        public SmtpClient GetClient()
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("buddyguardapp@outlook.com", "buddyguard123"),
                EnableSsl = true
            };

            return client;
        }
    }
}
