using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class InquiryService : IInquiryService
    {
        private readonly IRepository repository;

        public InquiryService(IRepository repository)
        {
            this.repository = repository;
        }

        public void SendInquiry(InquiryDTO data)
        {
            Inquiry inquiry = new Inquiry
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Phone = data.Phone,
                SentDate = DateTime.Now,
                Question = data.Inquiry
            };

            repository.Add(inquiry);

            repository.SaveChanges();
        }

        public List<InquiryDTO> GetInquiries()
        {
            var inquiries = repository.All<Inquiry>().Select(x => new InquiryDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                SentDate = x.SentDate,
                Inquiry = x.Question
            }).ToList();

            return inquiries;
        }
    }
}
