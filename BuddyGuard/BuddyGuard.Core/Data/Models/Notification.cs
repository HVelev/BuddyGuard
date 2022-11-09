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
        [Key]
        public int Id { get; set; }

        public DateTime ReceivedOn { get; set; }

        public bool IsRead { get; set; }

    }
}
