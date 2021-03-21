using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(User userFormData, string hashPassword, Guid id, DateTime createdAt, string rights);
        Task LoginUserAsync(string email, string password);
        Task<string> EncryptBySha256Hash(string password);
    }
}