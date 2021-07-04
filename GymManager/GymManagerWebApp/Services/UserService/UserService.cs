using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using GymManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using GymManagerWebApp.Models.Admin;

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
        public async Task<List<User>> GetUsersAsync(string currentUserEmail)
        {
            return await _dbContext.Users
                    .Where(x=>x.NormalizedEmail != currentUserEmail)
                    .Select(x => x).ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _dbContext.Users
                    .SingleOrDefaultAsync(x => x.Id == userId);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                    .SingleOrDefaultAsync(x => x.Email == email);
        }
        public async Task<User> UpdateUser(User user)
        {
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Where(x => x.Email == email)
                .Select(x => x.Id)
                .SingleOrDefaultAsync();
        }
        public List<User> SortUsersByEmails(List<User> users)
        {
            return users.OrderBy(x => x.Email).ToList();
        }
        public User CreateAddUserVievModel(AddUserViewModel model)
        {
            var user = new User()
            {
                FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Substring(1),
                LastName = char.ToUpper(model.LastName[0]) + model.LastName.Substring(1),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                CreatedAt = DateTime.UtcNow,
            };
            return user;
        }
        public async Task<string> GetRoleName (User user)
        {
            var roleId = _dbContext.UserRoles
                .Where(x => x.UserId == user.Id)
                .Select(x => x.RoleId)
                .ToString();
                
            var roleName = await _dbContext.Roles
                .Where(x => x.Id == roleId)
                .Select(x => x.Name)
                .SingleOrDefaultAsync();

            return roleName;
        }
        public EditUserViewModel CreateEditUserViewModel (User user, string userRole, List<string> allRoles)
        {
            var userViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                AllRoles = allRoles,
                CurrentUserRole = userRole,
            };
            return userViewModel;
        }
        public User CreateUpdatedUserModel(User user, EditUserViewModel model)
        {
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            return user;
        }
        public async Task<IdentityResult> CreateUser (AddUserViewModel model)
        {
            var newUser = CreateAddUserVievModel(model);
            await _userManager.AddToRoleAsync(newUser, model.Role);
            var result = await _userManager.CreateAsync(newUser, model.Password1);

            return result;
        }
        public async Task<IdentityResult> RemoveUser (string userId)
        {
            var userToRemove = await _userManager.FindByIdAsync(userId);
            return await _userManager.DeleteAsync(userToRemove);
        }
        public async Task<IdentityResult> UpdateUser (EditUserViewModel newModel)
        {
            var userToUpdate = await _userManager.FindByIdAsync(newModel.Id);

            await UpdateUserRole(userToUpdate, newModel.CurrentUserRole);
            var updatedUser = CreateUpdatedUserModel(userToUpdate, newModel);

            return await _userManager.UpdateAsync(updatedUser);
        }
        public async Task UpdateUserRole(User userToUpdate, string newRole)
        {
            var roles = await _userManager.GetRolesAsync(userToUpdate);
            await _userManager.RemoveFromRolesAsync(userToUpdate, roles);
            await _userManager.AddToRoleAsync(userToUpdate, newRole);
        }
    }
}