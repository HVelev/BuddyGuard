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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(new Service()
            {
                Id = 1,
                AnimalTypeId = 1,
                Name = "Две разходки без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 2
            },
            new Service()
            {
                Id = 2,
                AnimalTypeId = 1,
                Name = "Две разходки с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 3
            },
            new Service()
            {
                Id = 3,
                AnimalTypeId = 1,
                Name = "Разходка без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 1
            },
            new Service()
            {
                Id = 4,
                AnimalTypeId = 1,
                Name = "Разходка с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 2
            },
            new Service()
            {
                Id = 5,
                AnimalTypeId = 1,
                Name = "Две разходки без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 4
            },
            new Service()
            {
                Id = 6,
                AnimalTypeId = 1,
                Name = "Две разходки с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 9
            },
            new Service()
            {
                Id = 7,
                AnimalTypeId = 1,
                Name = "Разходка без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 11
            },
            new Service()
            {
                Id = 8,
                AnimalTypeId = 1,
                Name = "Разходка с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 3
            },
            new Service()
            {
                Id = 9,
                AnimalTypeId = 1,
                Name = "Две разходки без камера",
                WalkLength = "Комбинирана (30мин + 60мин)",
                IsForCustomer = false,
                PriceId = 6
            },
            new Service()
            {
                Id = 10,
                AnimalTypeId = 1,
                Name = "Две разходки с камера",
                WalkLength = "Комбинирани (30мин + 60мин)",
                IsForCustomer = false,
                PriceId = 8
            },
            new Service()
            {
                Id = 11,
                AnimalTypeId = 2,
                Name = "Две разходки без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 6
            },
            new Service()
            {
                Id = 12,
                AnimalTypeId = 2,
                Name = "Две разходки с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 8
            },
            new Service()
            {
                Id = 13,
                AnimalTypeId = 2,
                Name = "Разходка без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 2
            },
            new Service()
            {
                Id = 14,
                AnimalTypeId = 2,
                Name = "Разходка с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                PriceId = 6
            },
            new Service()
            {
                Id = 15,
                AnimalTypeId = 2,
                Name = "Две разходки без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 5
            },
            new Service()
            {
                Id = 16,
                AnimalTypeId = 2,
                Name = "Две разходки с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 10
            },
            new Service()
            {
                Id = 17,
                AnimalTypeId = 2,
                Name = "Разходка без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 3
            },
            new Service()
            {
                Id = 18,
                AnimalTypeId = 2,
                Name = "Разходка с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                PriceId = 8
            },
            new Service()
            {
                Id = 19,
                AnimalTypeId = 2,
                Name = "Две разходки без камера",
                IsForCustomer = false,
                WalkLength = "Комбинирани (30мин + 60мин)",
                PriceId = 7
            },
            new Service()
            {
                Id = 20,
                AnimalTypeId = 2,
                Name = "Две разходки с камера",
                IsForCustomer = false,
                WalkLength = "Комбинирани (30мин + 60мин)",
                PriceId = 9
            },
            new Service()
            {
                Id = 21,
                Name = "Еднократно ресане",
                IsForCustomer = false,
                PriceId = 17
            },
            new Service()
            {
                Id = 22,
                Name = "Цялостно къпане",
                IsForCustomer = false,
                PriceId = 18
            },
            new Service()
            {
                Id = 23,
                AnimalTypeId = 3,
                Name = "Разходка навън",
                IsForCustomer = false,
                PriceId = 19
            },
            new Service()
            {
                Id = 24,
                Name = "Ветеринарен преглед",
                IsForCustomer = false,
                PriceId = 15
            },
            new Service()
            {
                Id = 25,
                Name = "Събиране на поща",
                IsForCustomer = true,
                PriceId = 13
            },
            new Service()
            {
                Id = 26,
                Name = "Посрещане/Изпращане на пратка",
                IsForCustomer = true,
                PriceId = 13
            },
            new Service()
            {
                Id = 27,
                Name = "Еднократно поливане на цветя",
                IsForCustomer = true,
                PriceId = 14
            });
        }
    }
}
