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
        private IUserValidation _userValidation;
        private IUserRepository _userRepository;

        public UserController(IUserService userService, IUserValidation userValidation, IUserRepository userRepository)
        {
            _userService = userService;
            _userValidation = userValidation;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            var login = new Login();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAsync(Login login)
        {
            if (ModelState.IsValid)
            {
                //Adjustment format to compare entered user with users from DB
                login.Email = login.Email.ToLower();
                login.Password = await _userService.EncryptBySha256Hash(login.Password);

                if (await _userValidation.ValidateLogInAsync(login))
                {
                    var activeUser = await _userService.LoginUserAsync(login.Email,login.Password);
                    return View("UserHomePage", activeUser);
                }
            }
            return View("LogIn", login);
        }

        
        [HttpGet]
        public IActionResult SignIn()
        {
            var user = new User();
            return View(user);
        }

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

                if (await _userValidation.ValidateSignInAsync(model))
                {
                    var result = await _userRepository.CreateUserAsync(model);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                    ModelState.Clear();
                }
            }
            return View();
        }
    }



}



