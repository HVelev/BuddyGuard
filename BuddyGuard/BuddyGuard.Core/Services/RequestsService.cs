using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
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
        private readonly IRepository repository;

        public RequestsService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task SubmitForm(EditRequestDTO form)
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
            var entity = repository.Add(request);

            await repository.SaveChangesAsync();

            foreach (var rs in form.Services)
            {
                RequestService requestService = new RequestService()
                {
                    RequestId = entity.Id,
                    ServiceId = rs
                };

                repository.Add(requestService);
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

                var animalRequestEntity = repository.Add(petRequest);

                await repository.SaveChangesAsync();

                foreach (var petService in pet.Services)
                {
                    RequestService requestService = new RequestService()
                    {
                        RequestId = entity.Id,
                        ServiceId = petService,
                        AnimalRequestId = animalRequestEntity.Id
                    };

                    repository.Add(requestService);
                }
            }

            await repository.SaveChangesAsync();
        }
    }
}
