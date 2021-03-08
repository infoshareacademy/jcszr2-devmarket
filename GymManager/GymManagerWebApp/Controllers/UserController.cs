using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult PostUser(User user)
        {
            //var isValid = ValidateUser();
            return null;
        }

        //public bool ValidateUser(User user)
        //{

        //}
    }
}
