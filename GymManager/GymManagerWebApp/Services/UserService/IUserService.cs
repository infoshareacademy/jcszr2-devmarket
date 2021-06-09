using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Services
{
    public interface IUserService
    {
        [Authorize(Roles = "Admin")]
        Task<User> GetUserByEmailAsync(string email);
        [Authorize(Roles = "Admin")]
        Task<User> GetUserByIdAsync(string userId);
        Task<List<User>> GetUsersAsync(string currentUserEmail);
        Task<SignInResult> LoginAsync(Login login);
        Task LogoutAsync();
    }
}