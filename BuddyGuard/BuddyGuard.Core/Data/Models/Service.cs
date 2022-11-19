﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? WalkLength { get; set; }

        [Required]
        public bool IsForCustomer{ get; set; }

        public int? AnimalTypeId { get; set; }

        [Required]
        public int PriceId { get; set; }

        public Price Price { get; set; }
    }
}
