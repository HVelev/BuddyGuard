using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class RequestService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RequestId { get; set; }

        public Request Request { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int? AnimalRequestId { get; set; }

        public AnimalRequest AnimalRequest { get; set; }
    }
}
