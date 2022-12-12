using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.Core.Contracts
{
    public interface IRequestService
    {
        void SubmitForm(EditRequestDTO form);

        RequestDTO GetRequest(int requestId);

        List<RequestDTO> GetAllRequests(bool isForNotif);

        string DeleteRequest(int id);

        public void MarkRequestAsRead(int id);

        public string AcceptRequest(int id);

    }
}
