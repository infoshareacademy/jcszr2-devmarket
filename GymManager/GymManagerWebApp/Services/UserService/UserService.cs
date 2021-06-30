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
using System.Net;
using Microsoft.AspNetCore.Authorization;
using GymManagerWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GymManagerContext _dbContext;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, GymManagerContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
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

        [Authorize(Roles = "Administrator")]
        public async Task<List<User>> GetUsersAsync(string currentUserEmail)
        {
            return await _dbContext.Users
                    .Where(x=>x.NormalizedEmail != currentUserEmail)
                    .Select(x => x).ToListAsync();
        }


        [Authorize(Roles = "Administrator")]
        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _dbContext.Users
                    .SingleOrDefaultAsync(x => x.Id == userId);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                    .SingleOrDefaultAsync(x => x.Email == email);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<User> UpdateUser(User user)
        {

            await _dbContext.SaveChangesAsync();
            return user;
        }



    }
}