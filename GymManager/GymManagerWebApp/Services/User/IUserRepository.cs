using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string email);
        Task AddUserAsync(User userFormData, string hashPassword, Guid id, DateTime createdAt, string rights);
        Task<IList<User>> GetUsersAsync();
    }
}