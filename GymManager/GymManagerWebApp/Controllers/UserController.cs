using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GymManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [Route("LogIn")]
        [HttpGet]
        public IActionResult LogIn()
        {
            var login = new Login();
            return View(login);
        }

        [Route("LogIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAsync(Login login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(login);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }    
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("","Nieprawidłowe dane logowania. Spróbój ponownie");
            }
            return View("LogIn", login);
        }

        [Route("Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("SignIn")]
        [HttpGet]
        public IActionResult SignIn()
        {
            var user = new SignInUserViewModel();
            return View(user);
        }

        [Route("SignIn")]
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignInAsync(SignInUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Gender = HttpContext.Request.Form["Gender"].ToString();
                model.CreatedAt = DateTime.UtcNow;
                model.FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Substring(1);
                model.LastName = char.ToUpper(model.LastName[0]) + model.LastName.Substring(1);
                

                var result = await _userService.CreateUserAsync(model);
                var user = await _userService.GetUserByEmailAsync(model.Email);

                if (result.Succeeded)
                {
                    if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                    {
                        var role = HttpContext.Request.Form["Role"].ToString();
                        await _userManager.AddToRoleAsync(user, role);
                        return View("SignInConfirmation");
                    }
                    await _userManager.AddToRoleAsync(user, "Customer");
                    return View("SignInConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.Clear();
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            var userId = TempData["userId"].ToString();
            var user = await _userService.GetUserByIdAsync(userId);
            return View(user);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(User model, string role)
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
            if(result.Succeeded)
            {
                return View("EditConfirmation");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> CrudUsers(CrudUsersViewModel model)
        {
            var currentUserEmail = User.Identity.Name;
            model.Users = await _userService.GetUsersAsync(currentUserEmail);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CrudUsers(CrudUsersViewModel model,string btnAddUser, string btnEditUser,
            string btnLockUser, string btnLockoutUser, string btnDeleteUser)
        {
            
            if (!string.IsNullOrEmpty(btnAddUser)) {
                return RedirectToAction(nameof(SignIn));
            }
            else if(!string.IsNullOrEmpty(btnEditUser)) {
                TempData["userId"] = btnEditUser;
                return RedirectToAction(nameof(EditUser));
            }
            else if (!string.IsNullOrEmpty(btnLockUser))
            {
                TempData["userId"] = btnLockUser;
                return RedirectToAction(nameof(LockUser));
            }
            else if (!string.IsNullOrEmpty(btnLockUser))
            {
                TempData["userId"] = btnLockoutUser;
                return RedirectToAction(nameof(LockOutUser));
            }
            else if (!string.IsNullOrEmpty(btnDeleteUser))
            {
                TempData["userId"] = btnDeleteUser;
                return RedirectToAction(nameof(RemoveUser));
            }

            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> RemoveUser()
        {
            var userId = TempData["userId"].ToString();
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return View("DeleteConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("CrudUsers");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> LockUser(User user)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> LockOutUser(User user)
        {
            return View();
        }

    }
}



