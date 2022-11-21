using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class AnimalRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AnimalName { get; set; }

        public string? AnimalSpecies { get; set; }

        public string? PetDescription { get; set; }

        [Required]
        public int RequestId { get; set; }

        public Request Request { get; set; }

        [Required]
        public int AnimalTypeId { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
