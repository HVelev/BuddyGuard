using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.Core.Contracts
{
    public interface IRequestService
    {
        Task SubmitForm(EditRequestDTO form);
    }
}
