using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime? MeetingDate { get; set; }

        public bool IsRead { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime RequestSentDate { get; set; }

        public string? Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int LocationId { get; set; }
        
        public Location Location { get; set; }
    }
}