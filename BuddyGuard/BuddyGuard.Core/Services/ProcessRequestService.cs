using Amazon.Runtime.Internal;
using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
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
        private readonly IRepository repository;

        public ProcessRequestService(IRepository repository)
        {
            this.repository = repository;
        }


        public RequestDTO GetRequest(int requestId)
        {
            string location = repository.All<Request>(x => x.Id == requestId).Include(x => x.Location).First().Location.Name;

            RequestDTO request = 
                (from requests in repository.All<Request>()
                join user in repository.All<User>() on requests.UserId equals user.Id
                where requests.Id == requestId
                select new RequestDTO
                {
                    Id = requestId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Location = location,
                    Address = requests.Address,
                    StartDate = requests.StartDate,
                    EndDate = requests.EndDate,
                    SentDate = requests.RequestSentDate,
                    Comment = requests.Comment,
                    ClientServices = requests.RequestServices.Where(x => x.AnimalRequestId == null).Select(x => x.Service.Name).ToArray(),
                    MeetingDate = requests.MeetingDate,
                    Price = requests.Price
                }
            ).First();

            var animalRequestServices = repository.All<RequestService>(x => x.RequestId == requestId && x.AnimalRequestId != null).Include(x => x.Service).ToList();

            PetDTO[] pets = (from req in repository.All<Request>()
            where req.Id == requestId
            join ar in repository.All<AnimalRequest>() on req.Id equals ar.RequestId
            join at in repository.All<AnimalType>() on ar.AnimalTypeId equals at.Id
            select new PetDTO
            {
                Name = ar.AnimalName,
                AnimalType = at.Name,
                PetDescription = ar.PetDescription,
                Species = ar.AnimalSpecies,
                DogWalkLength = repository.All<RequestService>().Where(x => x.RequestId == requestId && x.AnimalRequestId == ar.Id && x.Service.WalkLength != null).Select(x => x.Service.Name).First(),
                Services = repository.All<RequestService>().Where(x => x.RequestId == requestId && x.AnimalRequestId == ar.Id).Include(x => x.Service).Select(x => x.Service.Name).ToArray()
            }
            ).ToArray();

            request.Pets = pets;

            return request;
        }

        public List<RequestDTO> GetAllRequests(bool isForNotif, bool isAccepted)
        {
            var result = repository.All<Request>().Where(r => isForNotif ? !r.IsRead : true && r.IsAccepted == isAccepted).Include(r => r.Location).Include(r => r.User).Include(r => r.RequestServices).ThenInclude(rs => rs.Service);

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
            var request = repository.GetById<Request>(id);
            request.IsRead = true;

            repository.SaveChanges();
        }

        public string AcceptRequest(int id)
        {
            var request = repository.GetById<Request>(id);
            request.IsAccepted = true;

            repository.SaveChanges();

            string email = repository.GetById<User>(request.UserId).Email;

            return email;
        }

        public string DeleteRequest(int id)
        {
            var entity = repository.GetById<Request>(id);

            repository.Delete<Request>(id);

            repository.SaveChanges();

            string email = repository.GetById<User>(entity.UserId).Email;

            return email;
        }
    }
}
