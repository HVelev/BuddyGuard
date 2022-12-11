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
                Price = 7.99M
            },
            new Service()
            {
                Id = 2,
                AnimalTypeId = 1,
                Name = "Две разходки с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 13.99M
            },
            new Service()
            {
                Id = 3,
                AnimalTypeId = 1,
                Name = "Разходка без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 4.99M
            },
            new Service()
            {
                Id = 4,
                AnimalTypeId = 1,
                Name = "Разходка с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 7.99M
            },
            new Service()
            {
                Id = 5,
                AnimalTypeId = 1,
                Name = "Две разходки без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 15.99M
            },
            new Service()
            {
                Id = 6,
                AnimalTypeId = 1,
                Name = "Две разходки с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 23.99M
            },
            new Service()
            {
                Id = 7,
                AnimalTypeId = 1,
                Name = "Разходка без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 9.99M
            },
            new Service()
            {
                Id = 8,
                AnimalTypeId = 1,
                Name = "Разходка с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 13.99M
            },
            new Service()
            {
                Id = 9,
                AnimalTypeId = 1,
                Name = "Две разходки без камера",
                WalkLength = "Комбинирани (30мин + 60мин)",
                IsForCustomer = false,
                Price = 11.99M
            },
            new Service()
            {
                Id = 10,
                AnimalTypeId = 1,
                Name = "Две разходки с камера",
                WalkLength = "Комбинирани (30мин + 60мин)",
                IsForCustomer = false,
                Price = 18.99M
            },
            new Service()
            {
                Id = 11,
                AnimalTypeId = 2,
                Name = "Две разходки без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 11.99M
            },
            new Service()
            {
                Id = 12,
                AnimalTypeId = 2,
                Name = "Две разходки с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 18.99M
            },
            new Service()
            {
                Id = 13,
                AnimalTypeId = 2,
                Name = "Разходка без камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 7.99M
            },
            new Service()
            {
                Id = 14,
                AnimalTypeId = 2,
                Name = "Разходка с камера",
                WalkLength = "30 минути",
                IsForCustomer = false,
                Price = 11.99M
            },
            new Service()
            {
                Id = 15,
                AnimalTypeId = 2,
                Name = "Две разходки без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 20.99M
            },
            new Service()
            {
                Id = 16,
                AnimalTypeId = 2,
                Name = "Две разходки с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 5.99M
            },
            new Service()
            {
                Id = 17,
                AnimalTypeId = 2,
                Name = "Разходка без камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 4.99M
            },
            new Service()
            {
                Id = 18,
                AnimalTypeId = 2,
                Name = "Разходка с камера",
                WalkLength = "60 минути",
                IsForCustomer = false,
                Price = 14.99M
            },
            new Service()
            {
                Id = 19,
                AnimalTypeId = 2,
                Name = "Две разходки без камера",
                IsForCustomer = false,
                WalkLength = "Комбинирани (30мин + 60мин)",
                Price = 16.99M
            },
            new Service()
            {
                Id = 20,
                AnimalTypeId = 2,
                Name = "Две разходки с камера",
                IsForCustomer = false,
                WalkLength = "Комбинирани (30мин + 60мин)",
                Price = 23.99M
            },
            new Service()
            {
                Id = 21,
                Name = "Еднократно ресане",
                IsForCustomer = false,
                Price = 4.99M
            },
            new Service()
            {
                Id = 22,
                Name = "Цялостно къпане",
                IsForCustomer = false,
                Price = 14.99M
            },
            new Service()
            {
                Id = 23,
                AnimalTypeId = 3,
                Name = "Разходка навън",
                IsForCustomer = false,
                Price = 5.99M
            },
            new Service()
            {
                Id = 24,
                Name = "Ветеринарен преглед",
                IsForCustomer = false,
                Price = 19.99M
            },
            new Service()
            {
                Id = 25,
                Name = "Събиране на поща",
                IsForCustomer = true,
                Price = 3.50M
            },
            new Service()
            {
                Id = 26,
                Name = "Посрещане/Изпращане на пратка",
                IsForCustomer = true,
                Price = 3.50M
            },
            new Service()
            {
                Id = 27,
                Name = "Еднократно поливане на цветя",
                IsForCustomer = true,
                Price = 2.99M
            });
        }
    }
}
