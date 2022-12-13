using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface IMailService
    {
        Task SendConfirmationEmail(string recipient);

        Task SendRejectionEmail(string recipient);
    }
}
