using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.FileReaders;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Services
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> _users = new List<User>();
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                PasswordHash = model.Password1,
                CreatedAt = model.CreatedAt,
                Role = model.Role,
            };

           var result = await _userManager.CreateAsync(user, model.Password1);
           return result;
        }


        public async Task<User> GetUserAsync(string email)
        {
            _users = await JsonManager.GetUsersAsync();
            return _users.SingleOrDefault(x => x.Email == email);
        }
        public async Task<IList<User>> GetUsersAsync()
        {
            _users = await JsonManager.GetUsersAsync();
            return _users;
        }

        public async Task AddUserAsync(User model)
        {
            var user = new User(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password1,
                model.Password1,
                model.PhoneNumber,
                model.Gender,
                model.Role,
                model.CreatedAt);

            await JsonManager.AddUserAsync(user);
        }

    }
}