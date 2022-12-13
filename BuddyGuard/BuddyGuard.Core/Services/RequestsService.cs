using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class RequestsService : IRequestService
    {
        private readonly BuddyguardDbContext dbContext;

        public RequestsService(BuddyguardDbContext db)
        {
            dbContext = db;
        }

        public void SubmitForm(EditRequestDTO form)
        {
            var request = new Request
            {
                LocationId = form.LocationId,
                Address = form.Address,
                UserId = form.UserId,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                RequestSentDate = DateTime.Now,
                MeetingDate = form.MeetingDate,
                Comment = form.Comment,
                Price = form.TotalAmount,
                IsRead = false,
                IsAccepted = false
            };

            var entity = dbContext.Requests.Add(request).Entity;
            
            dbContext.SaveChanges();

            foreach (var rs in form.Services)
            {
                RequestService requestService = new RequestService()
                {
                    RequestId = entity.Id,
                    ServiceId = rs
                };

                dbContext.RequestServices.Add(requestService);
            }

            foreach (var pet in form.Pets)
            {
                AnimalRequest petRequest = new AnimalRequest()
                {
                    AnimalName = pet.Name,
                    AnimalSpecies = pet.Species,
                    PetDescription = pet.PetDescription,
                    AnimalTypeId = pet.AnimalTypeId,
                    RequestId = entity.Id
                };

                var animalRequestEntity = dbContext.AnimalRequests.Add(petRequest).Entity;

                dbContext.SaveChanges();

                foreach (var petService in pet.Services)
                {
                    RequestService requestService = new RequestService()
                    {
                        RequestId = entity.Id,
                        ServiceId = petService,
                        AnimalRequestId = animalRequestEntity.Id
                    };

                    dbContext.RequestServices.Add(requestService);
                }
            }

            dbContext.SaveChanges();
        }
    }
}
