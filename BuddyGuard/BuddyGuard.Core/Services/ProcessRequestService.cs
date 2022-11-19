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

        public List<RequestDTO> GetAllUnreadRequests()
        {
            return dbContext.Requests.OrderByDescending(x => x.RequestSentDate).Select(x => new RequestDTO
            {
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                IsRead = x.IsRead,
                RequestSentDate = x.RequestSentDate
            }).ToList();
        }
    }
}
