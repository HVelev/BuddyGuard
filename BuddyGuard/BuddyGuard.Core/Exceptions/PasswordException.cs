using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Exceptions
{
    public class PasswordException : ArgumentException
    {
        public PasswordException(List<string> errorCodes)
        {
            ErrorCodes = errorCodes;
        }

        public List<string> ErrorCodes { get; set; }
    }
}
