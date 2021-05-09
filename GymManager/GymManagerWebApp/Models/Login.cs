using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Wymagany adres e-mail")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wymagane hasło")]
        [StringLength(20, ErrorMessage = "Podane hasło jest za krótkie- minimalna długość to {2} znaków", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Nieprawidłowe hasło. Hasło musi się składać z 6 znaków, 1 cyfry i 1 dużej litery")]
        public string Password { get; set; }
    }
}