namespace BuddyGuard.Core.Models
{
    public class RequestDTO
    {
        public RequestDTO()
        {
            Services = new List<int>();
        }

        public List<int> Services { get; set; }

        public decimal TotalAmount { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestSentDate { get; set; }

        public bool IsRead { get; set; }

        public bool IsAccepted { get; set; }
    }
}
