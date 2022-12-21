using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IProcessRequestService processRequestService;

        private readonly IInquiryService inquiryService;

        public NotificationService(IProcessRequestService processRequestService, IInquiryService inquiryService)
        {
            this.processRequestService = processRequestService;

            this.inquiryService = inquiryService;
        }

        public List<NotificationDTO> GetNotifications()
        {
            var notifications = new List<NotificationDTO>();

            var requestNotifications = processRequestService.GetAllRequests(true, false).Select(x => new NotificationDTO
            {
                Id = x.Id,
                SentDate = x.SentDate,
                StartDate = x.StartDate
            }).ToList();

            var inquiryNotifications = inquiryService.GetInquiries().Select(x => new NotificationDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SentDate = x.SentDate
            });

            notifications.AddRange(requestNotifications);
            notifications.AddRange(inquiryNotifications);

            return notifications;
        }
    }
}
