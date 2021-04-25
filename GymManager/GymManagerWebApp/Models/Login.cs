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
        [DataType(DataType.Password, ErrorMessage = "Nieprawidłowe hasło")]
        public string Password { get; set; }
    }
}