using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.Core.Contracts
{
    public interface IRequestService
    {
        void SubmitForm(FormDTO form);
    }
}
