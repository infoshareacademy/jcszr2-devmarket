using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.FileReaders;
using GymManagerWebApp.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GymManagerWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                PasswordHash = model.Password1,
                CreatedAt = model.CreatedAt,
            };

            var result = await _userManager.CreateAsync(user, model.Password1);
            await _userManager.AddToRoleAsync(user, "Customer");
            return result;
        }

        public async Task<SignInResult> LoginAsync(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }


    }
}