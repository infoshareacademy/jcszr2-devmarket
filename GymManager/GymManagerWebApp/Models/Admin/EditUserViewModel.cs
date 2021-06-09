using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Models.Admin
{
    public class EditUserViewModel : IdentityUser
    {
        [Required(ErrorMessage = "Wymagane imię")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Nieprawidłowe imię")]
        [RegularExpression(@"^\p{L}+(?: \p{L}+)*$", ErrorMessage = "Imię powinno składać się tylko z liter!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wymagane nazwisko")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Nieprawidłe nazwisko")]
        [RegularExpression(@"^\p{L}+(?: \p{L}+)*$", ErrorMessage = "Nawisko powinno składać się tylko z liter!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wymagany numer telefonu")]
        [Phone(ErrorMessage = "Numer telefonu powinien zawierać tylko cyfry!")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Nieprawidłowa długość- numer telefonu musi składać się z 9 cyfr!")]
        [DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Wymagany adres e-mail")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required(ErrorMessage = "Wymagane zaznaczenie płci")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Wymagane zaznaczenie uprawnień użytkownika")]
        public string CurrentUserRole { get; set; }
        public List<string> AllRoles { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
