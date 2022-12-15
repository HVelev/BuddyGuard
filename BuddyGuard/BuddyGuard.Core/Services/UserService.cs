using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class UserService : IUserService
    {
        private readonly BuddyguardDbContext db;

        public UserService(BuddyguardDbContext db)
        {
            this.db = db;
        }

        public UserDTO GetUser(string id)
        {
            return db.Users.Where(x => x.Id == id).Select(x => new UserDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.PhoneNumber
            }).First();
        }
    }
}
