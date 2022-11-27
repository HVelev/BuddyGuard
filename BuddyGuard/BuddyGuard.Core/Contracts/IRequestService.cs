using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.Core.Contracts
{
    public interface IRequestService
    {
        void SubmitForm(EditRequestDTO form);

        RequestDTO GetRequest(int requestId);

        List<RequestDTO> GetAllUnreadRequests();
    }
}
