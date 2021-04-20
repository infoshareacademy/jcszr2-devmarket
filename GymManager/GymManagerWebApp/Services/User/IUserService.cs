using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(User model);
        Task<User> LoginUserAsync(string email, string password);
        Task<string> EncryptBySha256Hash(string password);
        Task<bool> FindUser(string email, string password);
    }
}