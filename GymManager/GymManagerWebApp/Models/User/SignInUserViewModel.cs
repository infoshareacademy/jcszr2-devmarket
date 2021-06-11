using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using Microsoft.AspNetCore.Http;

namespace GymManagerWebApp.Models
{
    public class SignInUserViewModel : IdentityUser
    {
        [Required(ErrorMessage = "Wymagane imię")]
        [StringLength(maximumLength: 20, MinimumLength= 3,ErrorMessage ="Nieprawidłowe imię")]
        [RegularExpression(@"^\p{L}+(?: \p{L}+)*$", ErrorMessage = "Imię powinno składać się tylko z liter!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wymagane nazwisko")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Nieprawidłe nazwisko")]
        [RegularExpression(@"^\p{L}+(?: \p{L}+)*$", ErrorMessage = "Nawisko powinno składać się tylko z liter!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Wymagany numer telefonu")]
        [Phone(ErrorMessage ="Numer telefonu powinien zawierać tylko cyfry!")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Nieprawidłowa długość- numer telefonu musi składać się z 9 cyfr!")]
        [DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get; set; }
        
        [Required(ErrorMessage ="Wymagany adres e-mail")]
        [EmailAddress(ErrorMessage ="Nieprawidłowy adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required(ErrorMessage ="Wymagane hasło")]
        [StringLength(20, ErrorMessage = "Podane hasło jest za krótkie- minimalna długość to {2} znaków", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Nieprawidłowe hasło. Hasło musi się składać z 6 znaków, 1 cyfry i 1 dużej litery")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [Required(ErrorMessage =("Wymagane potwierdzenie hasła"))]
        [StringLength(20, ErrorMessage = "Podane hasło jest za krótkie- minimalna długość to {2} znaków", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Nieprawidłowe hasło. Hasło musi się składać z 6 znaków, 1 cyfry i 1 dużej litery")]
        [Compare(otherProperty:"Password1",ErrorMessage ="Podane hasła nie pasujądo siebie, wpisz 2 takie same hasła")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        [Required(ErrorMessage ="Wymagane zaznaczenie płci")]
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public static object Identity { get; internal set; }


    }
}