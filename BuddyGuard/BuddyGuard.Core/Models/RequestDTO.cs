
namespace BuddyGuard.Core.Models
{
    public class RequestDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime SentDate { get; set; }

        public string Location { get; set; }

        public string ExactLocation { get; set; }

        public DateTime? MeetingDate { get; set; }

        public string[]? ClientServices { get; set; }

        public string? Comment { get; set; }

        public PetDTO[] Pets { get; set; }
    }
}