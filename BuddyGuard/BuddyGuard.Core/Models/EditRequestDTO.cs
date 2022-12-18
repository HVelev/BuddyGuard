using System.ComponentModel.DataAnnotations;

namespace BuddyGuard.Core.Models
{
    public class EditRequestDTO
    {
        public EditRequestDTO()
        {
            Services = new List<int>();
        }

        public decimal TotalAmount { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LocationId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public DateTime RequestSentDate { get; set; }

        public DateTime? MeetingDate { get; set; }

        public string? Comment { get; set; }

        public bool IsRead { get; set; }
        
        [Required]
        public EditPetDTO[] Pets { get; set; }

        public List<int> Services { get; set; }

        public bool IsAccepted { get; set; }
    }
}
