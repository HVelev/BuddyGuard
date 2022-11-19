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

        public void SubmitForm(RequestDTO form)
        {
            var request = new Request
            {
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                RequestSentDate = DateTime.Now,
                IsRead = false,
                IsAccepted = false
            };

            dbContext.Requests.Add(request);

            dbContext.SaveChanges();
        }
    }
}
