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


namespace GymManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserValidation _userValidation;

        public UserController(IUserService userService, IUserValidation userValidation)
        {
            _userService = userService;
            _userValidation = userValidation;
        }

        #region Login
        [HttpGet]
        public IActionResult LogIn()
        {
            var login = new Login();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> LogInAsync(Login login)
        {
            string hashPassword = await _userService.EncryptBySha256Hash(login.Password);
            if (await _userValidation.IsLogInValid(login))
            {
                await _userService.LoginUserAsync(login.Email, hashPassword);
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotEmail()
        {
            return View();
        }


        #endregion
        #region Register
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
                if (await _userValidation.IsSignInValidBackEnd(model))
                {
                    //setting user data which are not input by the user in the signin form
                    model.Gender = HttpContext.Request.Form["Gender"].ToString();
                    Guid id = Guid.NewGuid();
                    DateTime createdAt = DateTime.UtcNow;
                    string rights = "standard user";

                    string hashPassword = await _userService.EncryptBySha256Hash(model.Password1);
                    await _userService.RegisterUserAsync(model, hashPassword, id, createdAt, rights);
                    return RedirectToAction("SignInSuccess", model);
                }
            }
            return View();
        }
        #endregion
            
    }



}
