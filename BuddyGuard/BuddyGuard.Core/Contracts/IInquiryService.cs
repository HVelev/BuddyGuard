using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface IInquiryService
    {
        void SendInquiry(InquiryDTO data);

        List<InquiryDTO> GetInquiries();
    }
}
