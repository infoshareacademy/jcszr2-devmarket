using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using GymManagerWebApp.Models.Admin;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.RolesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GymManagerWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CarnetController> _logger;

        public AdminController(IUserService userService, IRoleService roleService, UserManager<User> userManager, ILogger<CarnetController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _roleService = roleService;
            _logger = logger;
        }

        #region CRUD routing
        [HttpGet]
        public async Task<IActionResult> CrudUsers(CrudUsersViewModel model)
        {
            var currentUserEmail = User.Identity.Name;
            model.Users = await _userService.GetUsersAsync(currentUserEmail);
            model.Users = model.Users.OrderBy(x => x.Email).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult CrudUsers(CrudUsersViewModel model, string btnAddUser, string btnEditUser,
            string btnLockUser, string btnLockoutUser, string btnDeleteUser)
        {

            if (!string.IsNullOrEmpty(btnAddUser))
            {
                return RedirectToAction(nameof(AddUser));
            }

            if (!string.IsNullOrEmpty(btnEditUser))
            {
                TempData["userId"] = btnEditUser;
                return RedirectToAction(nameof(EditUser));
            }

            if (!string.IsNullOrEmpty(btnLockUser))
            {
                TempData["userId"] = btnLockUser;
                return RedirectToAction(nameof(LockUser));
            }

            if (!string.IsNullOrEmpty(btnLockUser))
            {
                TempData["userId"] = btnLockoutUser;
                return RedirectToAction(nameof(LockOutUser));
            }

            if (!string.IsNullOrEmpty(btnDeleteUser))
            {
                TempData["userId"] = btnDeleteUser;
                return RedirectToAction(nameof(RemoveUser));
            }
            return View();
        }
        #endregion
        #region Add
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            var model = new AddUserViewModel()
            {
                AllRoles = await _roleService.GetAllRoleNames()
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserAsync(AddUserViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var currentAdmin = _userService.GetUserByEmailAsync(User.Identity.Name);
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
            
                var result = await _userManager.CreateAsync(user, model.Password1); //adding user to db
                await _userManager.AddToRoleAsync(user, model.Role); //adding user role to db

                if (result.Succeeded)
                {
                    _logger.LogInformation($"Administrator with id: {currentAdmin.Id} | Added new user{user.Id}");
                    return View("Confirmations/AddUserConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogDebug($"Administrator with id: {currentAdmin.Id} | Failed to add new user | Details: {error.Description}");
                    ModelState.AddModelError("", error.Description);
                }
            }
            ModelState.Clear();
            return View();
        }
        #endregion
        #region Remove
        [HttpGet]
        public async Task<IActionResult> RemoveUser()
        {
            var userId = TempData["userId"].ToString();
            var user = await _userManager.FindByIdAsync(userId);
            var currentAdmin = _userService.GetUserByEmailAsync(User.Identity.Name);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _logger.LogInformation($"Administrator with id: {currentAdmin.Id} | Deleted user{user.Id}");
                return View("Confirmations/DeleteUserConfirmation");
            }
            foreach (var error in result.Errors)
            {
                _logger.LogDebug($"Administrator with id: {currentAdmin.Id} | Failed to delete user with id: {user.Id} | d=Details: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }
            return View("CrudUsers");
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            var userId = TempData["userId"].ToString();
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = (List<string>)await _userManager.GetRolesAsync(user);

            var editUserViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                AllRoles = await _roleService.GetAllRoleNames(),
                CurrentUserRole = userRoles.First(),
        };

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model, string Role)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            var currentAdmin = _userService.GetUserByEmailAsync(User.Identity.Name);

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, Role);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Administrator with id: {currentAdmin.Id} | Edited user{user.Id}");
                return View("Confirmations/EditUserConfirmation");
            }
            foreach (var error in result.Errors)
            {
                _logger.LogDebug($"Administrator with id: {currentAdmin.Id} | Failed to edit user with id: {user.Id} | Details: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        #endregion
        #region Lock
        [HttpGet]
        public async Task<IActionResult> LockUser(User user)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LockOutUser(User user)
        {
            return View();
        }
        #endregion
    }
}
