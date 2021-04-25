using System.Threading.Tasks;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserValidation
    {
        Task<bool> ValidateSignInAsync(User model);
        Task<bool> ValidateLogInAsync(Login login);
        bool IsNameValid(string name);
        bool IsPhoneValid(string phoneNr);
        bool IsEmailValid(string email);
        bool ArePasswordsValid(string password1, string password2);
        Task<bool> IsEmailExists(string email);
    }
}