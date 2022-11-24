namespace BuddyGuard.Core.Models
{
    public class FormDTO
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string? Species { get; set; }

        public string? DogWalk { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsRead { get; set; }

        public DateTime RequestSentDate { get; set; }
    }
}
