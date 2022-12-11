using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface IMailService
    {
        void SendConfirmationEmail(string recipient);

        void SendRejectionEmail(string recipient);
    }
}
