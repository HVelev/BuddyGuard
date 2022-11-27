
namespace BuddyGuard.Core.Models
{
    public class PetDTO
    {
        public string Name { get; set; }

        public string? Species { get; set; }

        public string? PetDescription { get; set; }

        public string AnimalType { get; set; }

        public string DogWalkLength { get; set; }

        public string[]? Services { get; set; }
    }
}
