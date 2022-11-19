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
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasData(new Price()
            {
                Id = 1,
                Amount = 5M
            },
            new Price()
            {
                Id = 2,
                Amount = 8M
            },
            new Price()
            {
                Id = 3,
                Amount = 14M
            },
            new Price()
            {
                Id = 4,
                Amount = 16M
            },
            new Price()
            {
                Id = 5,
                Amount = 21M
            },
            new Price()
            {
                Id = 6,
                Amount = 12M
            },
            new Price()
            {
                Id = 7,
                Amount = 17M
            },
            new Price()
            {
                Id = 8,
                Amount = 19M
            },
            new Price()
            {
                Id = 9,
                Amount = 24M
            },
            new Price()
            {
                Id = 10,
                Amount = 29M
            },
            new Price()
            {
                Id = 11,
                Amount = 10M
            },
            new Price()
            {
                Id = 12,
                Amount = 0M
            },
            new Price()
            {
                Id = 13,
                Amount = 3.50M
            },
            new Price()
            {
                Id = 14,
                Amount = 2.99M
            },
            new Price()
            {
                Id = 15,
                Amount = 19.99M
            },
            new Price()
            {
                Id = 16,
                Amount = 6M
            },
            new Price()
            {
                Id = 17,
                Amount = 4.99M
            },
            new Price()
            {
                Id = 18,
                Amount = 14.99M
            },
            new Price()
            {
                Id = 19,
                Amount = 5.99M
            });
        }
    }
}
