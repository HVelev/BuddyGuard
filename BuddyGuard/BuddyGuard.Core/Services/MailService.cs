using BuddyGuard.Core.Contracts;
using System.Net;
using System.Net.Mail;

namespace BuddyGuard.Core.Services
{
    public class MailService : IMailService
    {
        public void SendConfirmationEmail(string recipient)
        {
            MailAddress to = new MailAddress(recipient);
            MailAddress from = new MailAddress("buddyguardapp@outlook.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Одобрена заявка 🐶";
            message.Body = "Здравейте,\r\n\r\nВашата заявка е одобрена! Очаквайте служител да се свърже с Вас за потвърждаване на дата и час за среща. Благодарим, че избрахте BuddyGuard. \r\n\r\nПоздрави и до скоро!\r\n\r\nЗа допълнителни въпроси, моля свържете се с нас на този имейл или на телефон: +359877882390";
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

        public void SendRejectionEmail(string recipient)
        {
            MailAddress to = new MailAddress(recipient);
            MailAddress from = new MailAddress("buddyguardapp@outlook.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Отказана заявка 🐶";
            message.Body = "Здравейте,\r\n\r\nВашата заявка е отказана. В момента няма свободни гледачи, които да поемат грижите за домашния Ви любимец. Извиняваме се за причиненото неудобтсво!\r\n\r\nПоздрави,\r\nBuddyguard";
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
