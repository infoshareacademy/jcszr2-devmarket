using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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

        public void RegisterUser(User userFormData, Guid id, DateTime createdAt, string rights)
        {
            _userRepository.AddUser(userFormData, id, createdAt,rights);
        }

        

    }
}