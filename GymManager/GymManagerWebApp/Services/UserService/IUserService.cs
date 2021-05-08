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
        Task<IdentityResult> CreateUserAsync(User model);
        Task<List<User>> GetUsersAsync(string currentUserEmail);
        Task<SignInResult> LoginAsync(Login login);
        Task LogoutAsync();
    }
}