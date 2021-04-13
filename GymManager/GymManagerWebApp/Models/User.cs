using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace GymManagerWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Wymagane imię")]
        [StringLength(maximumLength: 20, MinimumLength= 3,ErrorMessage ="Nieprawidłowe imię")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wymagane nazwisko")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Nieprawidłe nazwisko")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Wymagany numer telefonu")]
        [Phone(ErrorMessage ="Nieprawidłowy nr telefonu- proszę wprowadzić 9 cyfrowy numer")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNr { get; set; }
        
        [Required(ErrorMessage ="Wymagany adres e-mail")]
        [EmailAddress(ErrorMessage ="Nieprawidłowy adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Wymagane hasło")]
        [StringLength(20, ErrorMessage = "Podane hasło jest za krótkie- minimalna długość to {2} znaków", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Nieprawidłowe hasło. Hasło musi się składać z 6 znaków, 1 cyfry i 1 dużej litery")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [Required(ErrorMessage =("Wymagane potwierdzenie hasła"))]
        [StringLength(20, ErrorMessage = "Podane hasło jest za krótkie- minimalna długość to {2} znaków", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Nieprawidłowe hasło. Hasło musi się składać z 6 znaków, 1 cyfry i 1 dużej litery")]
        [Compare(otherProperty:"Password1",ErrorMessage ="Proszę podać takie same hasła")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        [Required(ErrorMessage ="Wymagane zaznaczenie płci")]
        public string Gender { get; set; }
       
        public DateTime CreatedAt { get; set; }

        public string Rights { get; set; }

        public User()
        {
        }

        public User(Guid id, string firstName, string lastName, string email, string password1,
            string password2, string phoneNr, string gender, string rights, DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName= lastName;
            Email = email;
            Password1 = password1;
            Password2 = password2;
            PhoneNr = phoneNr;
            Gender = gender;
            Rights = rights;
            CreatedAt = createdAt;
        }
    }
}