using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(User model);
        Task<SignInResult> LoginAsync(Login login);
        Task LogoutAsync();
    }
}