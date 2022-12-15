using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
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
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public UserDTO GetUser(string id)
        {
            return repository.All<User>(x => x.Id == id).Select(x => new UserDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.PhoneNumber
            }).First();
        }
    }
}
