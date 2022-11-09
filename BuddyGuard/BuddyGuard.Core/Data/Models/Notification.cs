using BuddyGuard.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class Notification
    {
        public Notification()
        {
            Requests = new List<Request>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime ReceivedOn { get; set; }

        public bool IsRead { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
