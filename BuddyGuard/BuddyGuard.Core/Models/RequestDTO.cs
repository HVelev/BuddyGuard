namespace BuddyGuard.Core.Models
{
    public class RequestDTO
    {
        public RequestDTO()
        {
            Services = new List<int>();
        }


        public decimal TotalAmount { get; set; }

        public string UserId { get; set; }

        public int LocationId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime RequestSentDate { get; set; }

        public bool IsRead { get; set; }

        public PetDTO[] Pets { get; set; }

        public List<int> Services { get; set; }

        public bool IsAccepted { get; set; }
    }
}
