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

        [HttpGet]
        public async Task<IActionResult> UsersList(CrudUsersViewModel model)
        {
            var currentUserEmail = User.Identity.Name;

            model.Users = await _userService.GetUsersAsync(currentUserEmail);
            model.Users = _userService.SortUsersByEmails(model.Users);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserAsync()
        {
            var model = new AddUserViewModel();

            model.AllRoleNames = await _roleService.GetAllRoleNamesAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserAsync(AddUserViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var result = await _userService.CreateUser(model);

                var newUserId = await _userService.GetUserIdByEmailAsync(model.NormalizedEmail);
                var currentAdminId = await _userService.GetUserIdByEmailAsync(User.Identity.Name);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"Administrator with id: {currentAdminId} | Added new user{newUserId}");
                    return View("Confirmations/AddUserConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogError($"Administrator with id: {currentAdminId} | Failed to add new user | Details: {error.Description}");
                    ModelState.AddModelError("", error.Description);
                }
            }

            ModelState.Clear();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUser(string userId)
        {
            var currentAdminEmail = _userService.GetUserByEmailAsync(User.Identity.Name);
            var result = await _userService.RemoveUser(userId);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Administrator with id: {currentAdminEmail.Id} | Deleted user {userId}");
                return View("Confirmations/DeleteUserConfirmation");
            }

            foreach (var error in result.Errors)
            {
                _logger.LogDebug($"Administrator with id: {currentAdminEmail.Id} | Failed to delete user with id: {userId} | d=Details: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }

            return View("UsersList");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            var userToEdit = await _userManager.FindByIdAsync(userId);

            var userRoleName = await _userService.GetRoleName(userToEdit);

            var allRoleNames = await _roleService.GetAllRoleNamesAsync();

            var userViewModel = _userService.CreateEditUserViewModel(userToEdit, userRoleName, allRoleNames);

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var currentAdminEmail = _userService.GetUserByEmailAsync(User.Identity.Name);
            var result = await _userService.UpdateUser(model);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Administrator with id: {currentAdminEmail.Id} | Edited user{model.Id}");
                return View("Confirmations/EditUserConfirmation");
            }
            foreach (var error in result.Errors)
            {
                _logger.LogDebug($"Administrator with id: {currentAdminEmail.Id} | Failed to edit user with id: {model.Id} | Details: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}
