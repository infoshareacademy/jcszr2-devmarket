using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.FileReaders;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> _users = new List<User>();

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
                model.Id,
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password1,
                model.Password1,
                model.PhoneNr,
                model.Gender,
                model.Rights,
                model.CreatedAt);

            await JsonManager.AddUserAsync(user);
        }

    }
}