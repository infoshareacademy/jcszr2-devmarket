using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.FileReaders;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public class UserValidation : IUserValidation
    {
        
        public async Task<bool> IsValidAsync(User model)
        {
            if (await IsNotAlreadyRegisteredAsync(model.Email)
                && IsEmailValid(model.Email)
                && IsPasswordValid(model.Password1, model.Password2)
                && IsNameValid(model.FirstName)
                && IsNameValid(model.LastName)
                && IsPhoneValid(model.PhoneNr)
            ) return true;
            return false;
        }
        public async Task<bool> IsNotAlreadyRegisteredAsync(string email)
        {
            var users = await JsonManager.GetUsersAsync();
            email = email.ToLower();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new NotImplementedException($"Walidacja: Błąd, pole email nie może być puste!");
            }

            if ( users.Any(x => x.Email.Equals(email)))
            {
                throw new NotImplementedException($"Walidacja: Błąd, użytkownik o adresie email: {email} jest już zarejestrowany!");
            };
            return true;
        }
        public bool IsEmailValid(string email)
        {
            email = email.ToLower();
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
            var isEmptyOrWhiteSpacesPassword1 = string.IsNullOrWhiteSpace(password1);
            var isEmptyOrWhiteSpacesPassword2 = string.IsNullOrWhiteSpace(password2);

            var isValid = hasNumber.IsMatch(password1)
                          && hasUpperChar.IsMatch(password1)
                          && hasMinimum8Chars.IsMatch(password1)
                          && password1 == password2
                          && !isEmptyOrWhiteSpacesPassword1
                          && !isEmptyOrWhiteSpacesPassword2;

            if (isValid)
            {
                return true;
            }
            throw new NotImplementedException($"Walidacja: Nieprawidłowe hasło");
        }
        public bool IsNameValid(string name)
        {
            name = char.ToUpper(name[0]) + name.Substring(1);
            if (Regex.Match(name, "^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż]*$").Success &&
                !string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            throw new NotImplementedException($"Walidacja: Nieprawiłdowe dane: {name}");
        }
        public bool IsPhoneValid(string phoneNr)
        {
            if (Regex.Match(phoneNr, "^[0-9]{9}").Success && !string.IsNullOrWhiteSpace(phoneNr))
            {
                return true;
            }
            throw new NotImplementedException($"Walidacja: Nieprawiłdowe dane: {phoneNr}");
        }

    }
}