using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Constants
{
    public static class DataConstants
    {
        public static class S3Constants
        {
            public const string Key = "AKIAW4ROKHDZ7KHWLHUK";

            public const string SecretKey = "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";

            public const string BucketName = "buddyguard";

            public const string Descrpition = "description";
        }

        public static class MailConstants
        {
            public const string Email = "buddyguardapp@outlook.com";
            public const string Password = "buddyguard123";

            public const string SMTPServer = "smtp-mail.outlook.com";
            public const int SMTPPort = 587;

            public const string ConfirmationSubject = "Одобрена заявка 🐶";
            public const string ConfirmationBody = "Здравейте,\r\n\r\nВашата заявка е одобрена! Очаквайте служител да се свърже с Вас за потвърждаване на дата и час за среща. Благодарим, че избрахте BuddyGuard. \r\n\r\nПоздрави и до скоро!\r\n\r\nЗа допълнителни въпроси, моля свържете се с нас на този имейл или на телефон: +359877882390";
            
            public const string RejectionSubject = "Отказана заявка 🐶";
            public const string RejectionBody = "Здравейте,\r\n\r\nВашата заявка е отказана. В момента няма свободни гледачи, които да поемат грижите за домашния Ви любимец. Извиняваме се за причиненото неудобтсво!\r\n\r\nПоздрави,\r\nBuddyguard";
        }
    }
}
