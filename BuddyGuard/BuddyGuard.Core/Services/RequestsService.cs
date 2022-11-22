using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;
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
                UserId = form.UserId,
                StartDate = DateTime.Parse(form.StartDate),
                EndDate = DateTime.Parse(form.EndDate),
                RequestSentDate = DateTime.Now,
                Comment = form.Comment,
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

        public RequestDTO GetRequest(int requestId)
        {
            RequestDTO request = (from requestDb in dbContext.Requests
                                  join user in dbContext.Users on requestDb.UserId equals user.Id
                                  join location in dbContext.Locations on requestDb.LocationId equals location.Id
                                  where requestDb.Id == requestId
                                  select new RequestDTO
                                  {
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      Email = user.Email,
                                      Phone = user.PhoneNumber,
                                      Location = location.Name,
                                      StartDate = requestDb.StartDate,
                                      EndDate = requestDb.EndDate,
                                      SentDate = requestDb.RequestSentDate,
                                      Comment = requestDb.Comment
                                  }).First();

            PetDTO[] pets = (from requestDb in dbContext.Requests
                             join animalRequest in dbContext.AnimalRequests on requestDb.Id equals animalRequest.RequestId
                             join animalType in dbContext.AnimalTypes on animalRequest.AnimalTypeId equals animalType.Id
                             select new PetDTO
                             {
                                 Name = animalRequest.AnimalName,
                                 AnimalType = animalType.Name,
                                 PetDescription = animalRequest.PetDescription,
                                 Species = animalRequest.AnimalSpecies
                             }).ToArray();

            request.Pets = pets;

            return request;
        }
    }
}
