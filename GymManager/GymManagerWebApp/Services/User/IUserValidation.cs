using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserValidation
    {
        bool IsValid(User model);
        bool IsNameValid(string name);
        bool IsPhoneValid(string phoneNr);
        bool IsEmailValid(string email);
        bool IsPasswordValid(string password1, string password2);
        bool IsNotAlreadyRegistered(string email);
    }
}