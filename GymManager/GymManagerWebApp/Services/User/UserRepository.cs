﻿using System;
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

        public async Task AddUserAsync(User userFormData, string hashPassword, Guid id, DateTime createdAt, string rights)
        {
            userFormData.FirstName = char.ToUpper(userFormData.FirstName[0]) + userFormData.FirstName.Substring(1);
            userFormData.LastName = char.ToUpper(userFormData.LastName[0]) + userFormData.LastName.Substring(1);
            userFormData.Email = userFormData.Email.ToLower();

            var user = new User(
                id,
                userFormData.FirstName,
                userFormData.LastName,
                userFormData.Email,
                hashPassword,
                hashPassword,
                userFormData.PhoneNr,
                userFormData.Gender,
                rights,
                createdAt);

            await JsonManager.AddUserAsync(user);
        }

    }
}