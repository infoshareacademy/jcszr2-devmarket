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
        private IUserService _userService;
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
            var user = new User();
            return View(user);
        }

        [Route("SignIn")]
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignInAsync(User model)
        {
            if (ModelState.IsValid)
            {
                model.Gender = HttpContext.Request.Form["Gender"].ToString();
                model.CreatedAt = DateTime.UtcNow;
                model.FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Substring(1);
                model.LastName = char.ToUpper(model.LastName[0]) + model.LastName.Substring(1);
                var result = await _userService.CreateUserAsync(model);

                if (result.Succeeded)
                {
                    if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                    {
                        var role = HttpContext.Request.Form["Role"].ToString();
                        await _userManager.AddToRoleAsync(model, role);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(model, "Customer");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                ModelState.Clear();
            }
            return View("SignInConfirmation");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            return View();
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
            string btnLockUser, string btnDeleteUser)
        {
            //var currentUserEmail = User.Identity.Name;
            
            if (!string.IsNullOrEmpty(btnAddUser)) {
                return RedirectToAction(nameof(SignIn));
            }
            else if(!string.IsNullOrEmpty(btnEditUser)) {
                var x = btnAddUser;
                return RedirectToAction();
            }
            else if (!string.IsNullOrEmpty(btnLockUser))
            {
                return RedirectToAction();
            }
            else if (!string.IsNullOrEmpty(btnDeleteUser))
            {
                return RedirectToAction();
            }

            //model.Users = await _userService.GetUsersAsync(currentUserEmail);
            return View();
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(User user)
        {

            var x = user.EmailConfirmed;
            return View("AddUserAdmin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUser(User user)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LockUser(User user)
        {
            return View();
        }

    }
}



