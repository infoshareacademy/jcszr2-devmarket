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

namespace GymManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
                //Data out of the form
                model.Gender = HttpContext.Request.Form["Gender"].ToString();
                model.CreatedAt = DateTime.UtcNow;
                model.Role = "standard";

                //Adjustment format to store in database
                model.FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Substring(1);
                model.LastName = char.ToUpper(model.LastName[0]) + model.LastName.Substring(1);

                var result = await _userService.CreateUserAsync(model);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                ModelState.Clear();

            }
            return View();
        }
    }



}



