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
    public class RequestService : IRequestService
    {
        private readonly BuddyguardDbContext dbContext;

        public RequestService(BuddyguardDbContext db)
        {
            dbContext = db;
        }

        public void SubmitForm(FormDTO form)
        {
            var request = new Request
            {
                Name = form.Name,
                AnimalInfo = form.Species,
                Phone = form.Phone,
                Email = form.Email,
                Location = form.Location,
                DogWalkLength = form.DogWalk,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                IsRead = form.IsRead,
                RequestSentDate = DateTime.Now
            };

            dbContext.Requests.Add(request);

            dbContext.SaveChanges();
        }
    }
}
