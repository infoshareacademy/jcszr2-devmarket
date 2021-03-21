using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.FileReaders;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(User userFormData, Guid id, DateTime createdAt, string rights)
        {
            await _userRepository.AddUserAsync(userFormData, id, createdAt,rights);
        }

        public async Task LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);
            if(user == null || user.Password1 != password)
            {
                throw new NotImplementedException("Nieprawidłowe dane logowania");
            }
        }

        

    }
}