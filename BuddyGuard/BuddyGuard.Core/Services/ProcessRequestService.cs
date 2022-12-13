using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class ProcessRequestService : IProcessRequestService
    {
        private readonly BuddyguardDbContext dbContext;

        public ProcessRequestService(BuddyguardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public RequestDTO GetRequest(int requestId)
        {
            RequestDTO request = (from requestDb in dbContext.Requests
                                  join user in dbContext.Users on requestDb.UserId equals user.Id
                                  join location in dbContext.Locations on requestDb.LocationId equals location.Id
                                  where requestDb.Id == requestId
                                  select new RequestDTO
                                  {
                                      Id = requestId,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      Email = user.Email,
                                      Phone = user.PhoneNumber,
                                      Location = location.Name,
                                      Address = requestDb.Address,
                                      StartDate = requestDb.StartDate,
                                      EndDate = requestDb.EndDate,
                                      SentDate = requestDb.RequestSentDate,
                                      Comment = requestDb.Comment,
                                      ClientServices = requestDb.RequestServices.Where(x => x.AnimalRequestId == null).Select(x => x.Service.Name).ToArray(),
                                      MeetingDate = requestDb.MeetingDate,
                                      Price = requestDb.Price
                                  }).First();

            var animalRequestServices = dbContext.RequestServices.Where(x => x.RequestId == requestId && x.AnimalRequestId != null).Include(x => x.Service).ToList();

            PetDTO[] pets = (from requestDb in dbContext.Requests
                             where requestDb.Id == requestId
                             join animalRequest in dbContext.AnimalRequests on requestDb.Id equals animalRequest.RequestId
                             join animalType in dbContext.AnimalTypes on animalRequest.AnimalTypeId equals animalType.Id
                             select new PetDTO
                             {
                                 Name = animalRequest.AnimalName,
                                 AnimalType = animalType.Name,
                                 PetDescription = animalRequest.PetDescription,
                                 Species = animalRequest.AnimalSpecies,
                                 DogWalkLength = dbContext.RequestServices.Where(x => x.RequestId == requestId && x.AnimalRequestId == animalRequest.Id && x.Service.WalkLength != null).Select(x => x.Service.Name).First(),
                                 Services = dbContext.RequestServices.Where(x => x.RequestId == requestId && x.AnimalRequestId == animalRequest.Id).Include(x => x.Service).Select(x => x.Service.Name).ToArray()
                             }).ToArray();

            request.Pets = pets;

            return request;
        }

        public List<RequestDTO> GetAllRequests(bool isForNotif, bool isAccepted)
        {
            var result = dbContext.Requests.Where(r => isForNotif ? !r.IsRead : true && r.IsAccepted == isAccepted).Include(r => r.Location).Include(r => r.User).Include(r => r.RequestServices).ThenInclude(rs => rs.Service);

            if (isForNotif)
            {
                return result.OrderByDescending(x => x.RequestSentDate).Select(x => new RequestDTO
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    SentDate = x.RequestSentDate,
                }).ToList();
            }
            else if (!isForNotif && !isAccepted)
            {
                return result.OrderBy(x => x.StartDate).Select(x => new RequestDTO
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Phone = x.User.PhoneNumber,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Location = x.Location.Name
                }).ToList();
            }
            else
            {
                return result.OrderBy(x => x.StartDate).Select(x => new RequestDTO
                {
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Phone = x.User.PhoneNumber,
                    MeetingDate = x.MeetingDate,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Location = x.Location.Name,
                    Address = x.Address
                }).ToList();
            }
        }

        public void MarkRequestAsRead(int id)
        {
            var request = dbContext.Requests.Where(x => x.Id == id).First();
            request.IsRead = true;

            dbContext.SaveChanges();
        }

        public string AcceptRequest(int id)
        {
            var request = dbContext.Requests.Where(x => x.Id == id).First();
            request.IsAccepted = true;

            dbContext.SaveChanges();

            return dbContext.Users.Where(x => x.Id == request.UserId).First().Email;
        }

        public string DeleteRequest(int id)
        {
            var entity = dbContext.Requests.Where(x => x.Id == id).First();

            dbContext.Requests.Remove(entity);

            dbContext.SaveChanges();

            return dbContext.Users.Where(x => x.Id == entity.UserId).First().Email;
        }
    }
}
