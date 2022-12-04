using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.Core.Contracts
{
    public interface IRequestService
    {
        void SubmitForm(EditRequestDTO form);

        RequestDTO GetRequest(int requestId);

        List<RequestDTO> GetAllRequests(bool isForNotif);

        void DeleteRequest(int id);

        public void MarkRequestAsRead(int id);

        public void AcceptRequest(int id);

    }
}
