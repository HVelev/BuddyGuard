using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Models
{
    public class AnimalDTO
    {
        public AnimalDTO()
        {
            AnimalServices = new List<int>();
        }

        [Required]
        public string Name { get; set; }

        public string Species { get; set; }

        [Required]
        public int AnimalType { get; set; }

        public List<int> AnimalServices { get; set; }
    }
}
