using System.Threading.Tasks;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserValidation
    {
        Task<bool> IsValidAsync(User model);
        bool IsNameValid(string name);
        bool IsPhoneValid(string phoneNr);
        bool IsEmailValid(string email);
        bool IsPasswordValid(string password1, string password2);
        Task<bool> IsNotAlreadyRegisteredAsync(string email);
    }
}