using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.FileReaders;
using GymManagerWebApp.Models;
using System.Text;
using System.Security.Cryptography;

namespace GymManagerWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(User userFormData, string hashPassword, Guid id, DateTime createdAt, string rights)
        {
            await _userRepository.AddUserAsync(userFormData, hashPassword, id, createdAt,rights);
        }

        public async Task LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);
            if(user == null || user.Password1 != password)
            {
                throw new NotImplementedException("Nieprawidłowe dane logowania");
            }
        }

        public async Task<string> EncryptBySha256Hash(string password)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}