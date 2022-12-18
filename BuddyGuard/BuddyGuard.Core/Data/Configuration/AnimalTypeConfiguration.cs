using BuddyGuard.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Configuration
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.HasData(CreatePetTypes());
        }

        public List<AnimalType> CreatePetTypes()
        {
            return new List<AnimalType>()
            {
                new AnimalType()
            {
                Id = 1,
                Name = "Малко куче"
            },
            new AnimalType()
            {
                Id = 2,
                Name = "Голямо куче"
            },
            new AnimalType()
            {
                Id = 3,
                Name = "Котка"
            },
            new AnimalType()
            {
                Id = 4,
                Name = "Друго"
            }
            };
        }
     }
}
