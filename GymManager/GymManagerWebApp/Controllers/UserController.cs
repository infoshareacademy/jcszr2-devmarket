using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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
        public IActionResult PostUser(User modelUser)
        {
            if (isValid(modelUser))
            {
                return View("SignInSuccess");
            }
            throw new NotImplementedException();
        }

        public bool isValid(User modelUser)
        {
            if (IsAlreadyRegistered(modelUser.Email)
                && IsNameValid(modelUser.FirstName)
                && IsNameValid(modelUser.SurName)
                && IsPhoneValid(modelUser.PhoneNr)
                && IsEmailValid(modelUser.Email)
                && IsPasswordValid(modelUser.Password, modelUser.RepeatedPassword)
                ) return true;
            return false;
        }
        public bool IsNameValid(string name)
        {

                return Regex.Match(name, "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż]*$").Success && !string.IsNullOrWhiteSpace(name);
            
        }
        public bool IsPhoneValid(string phoneNr)
        {

            if (Regex.Match(phoneNr, "^[0-9]{9}").Success && !string.IsNullOrWhiteSpace(phoneNr))
            {
                return true;
            }
            return false;

        }
        public bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                    return false;
            try
                {
                    // Normalize the domain
                    email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                        RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    // Examines the domain part of the email and normalizes it.
                    string DomainMapper(Match match)
                    {
                        // Use IdnMapping class to convert Unicode domain names.
                        var idn = new IdnMapping();

                        // Pull out and process domain name (throws ArgumentException on invalid)
                        string domainName = idn.GetAscii(match.Groups[2].Value);

                        return match.Groups[1].Value + domainName;
                    }
                }
                catch (RegexMatchTimeoutException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }

                try
                {
                    return Regex.IsMatch(email,
                        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
        }
        public bool IsPasswordValid(string password1, string password2)
        {
            
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");

                var isValid = hasNumber.IsMatch(password1) && hasUpperChar.IsMatch(password1) &&
                              hasMinimum8Chars.IsMatch(password1) && password1 == password2;

                return isValid;

            
        }
        public bool IsAlreadyRegistered(string email)
        {
            var users = new FileReaders.JsonReader().GetUsers();
            return users.Any(x => x.Email.Equals(email));
        }
    }
}
