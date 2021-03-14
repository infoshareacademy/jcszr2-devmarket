using System;
using System.Collections.Generic;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserRepository
    {
        User GetUser(string email);
        void AddUser(User userFormData, Guid id, DateTime createdAt, string rights);
        IList<User> GetUsers();
    }
}