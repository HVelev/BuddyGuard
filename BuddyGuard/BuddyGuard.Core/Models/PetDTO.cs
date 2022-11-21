using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Models
{
    public class PetDTO
    {

        [Required]
        public string Name { get; set; }

        public string? Species { get; set; }

        public string? PetDescription { get; set; }

        [Required]
        public int AnimalTypeId { get; set; }


        public int[] Services { get; set; }
    }
}
