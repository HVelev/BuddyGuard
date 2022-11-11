using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class LoginService : ILoginService
    {
        private BuddyguardDbContext db;

        public LoginService(BuddyguardDbContext db)
        {
            this.db = db;
        }

        public bool Login(User user)
        {
            var userDb = db.Users.Where(x => x.UserName == user.UserName && x.PasswordHash == user.PasswordHash);

            if (userDb.Count() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
