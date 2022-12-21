using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Exceptions;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace BuddyGuard.Core.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository repository;

        public RegisterService(UserManager<User> userManager, IRepository repository)
        {
            this.userManager = userManager;

            this.repository = repository;
        }
        public async Task Register(RegisterDTO userModel)
        {
            var doesUserExist = repository.All<User>().Where(x => x.Email == userModel.Email || x.UserName == userModel.Username).Count() > 0;

            if (doesUserExist)
            {
                throw new InvalidOperationException();
            }

            User user = new User
            {
                UserName = userModel.Username,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                PhoneNumber = userModel.Phone
            };

            var result = await userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                var codes = new List<string>();

                foreach (var error in result.Errors)
                {
                    codes.Add(error.Code);
                }

                throw new PasswordException(codes);
            }

            await userManager.AddToRoleAsync(user, userModel.Role);

            repository.SaveChanges();
        }
    }
}
