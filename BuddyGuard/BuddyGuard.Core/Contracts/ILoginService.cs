using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;

namespace BuddyGuard.Core.Contracts
{
    public interface ILoginService
    {
        Task<LoginDTO> Login(User user, string password);

        bool IsLoggedIn(string token);
    }
}
