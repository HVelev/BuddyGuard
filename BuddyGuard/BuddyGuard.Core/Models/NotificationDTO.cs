using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Models
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime SentDate { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
