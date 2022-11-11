using BuddyGuard.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Contracts
{
    public interface ILoginService
    {
        bool Login(User user);
    }
}
