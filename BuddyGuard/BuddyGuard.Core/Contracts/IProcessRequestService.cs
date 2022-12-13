using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface IProcessRequestService
    {
        List<RequestDTO> GetAllRequests(bool isForNotif, bool isAccepted);
        RequestDTO GetRequest(int requestId);
        void MarkRequestAsRead(int id);
        string AcceptRequest(int id);
        string DeleteRequest(int id);

    }
}
