using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GymManagerWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string SurName { get; set; }
        
        [Required]
        [Phone]
        public string PhoneNr { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        public string RepeatedPassword { get; set; }

        [Required]
        public string Gender { get; set; }
       
        public DateTime CreatedAt { get; set; }


    }
}