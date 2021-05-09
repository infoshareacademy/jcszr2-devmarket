using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Models.Admin;
using GymManagerWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<User> _roleManager;

        public AdminController(IUserService userService, UserManager<User> userManager, RoleManager<User> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #region CRUD redirect to operation manager
        [HttpGet]
        public async Task<IActionResult> CrudUsers(CrudUsersViewModel model)
        {
            var currentUserEmail = User.Identity.Name;
            model.Users = await _userService.GetUsersAsync(currentUserEmail);
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
        #region CRUD operations
        [HttpGet]
        public IActionResult AddUser()
        {
            var model = new AddUserViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserAsync(AddUserViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = _userService.InstantiateUser(model);
                var result = await _userManager.CreateAsync(user, model.Password1); //adding user to db
                await _userManager.AddToRoleAsync(user, model.Role); //adding user role to db

                if (result.Succeeded)
                {
                    return View("Confirmations/AddUserConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUser()
        {
            var userId = TempData["userId"].ToString();
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return View("Confirmations/DeleteUserConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("CrudUsers");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            var userId = TempData["userId"].ToString();
            var user = await _userManager.FindByIdAsync(userId);

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
                Role = await _roleManager.GetRoleNameAsync(user)
            };

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model, string role)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            await _userManager.AddToRoleAsync(user, role);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return View("Confirmations/EditUserConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

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
