using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Services
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string email);
        Task AddUserAsync(User model);
        Task<IList<User>> GetUsersAsync();
        Task<IdentityResult> CreateUserAsync(User model);
        Task<SignInResult> LoginAsync(Login login);
        Task LogoutAsync();
    }
}