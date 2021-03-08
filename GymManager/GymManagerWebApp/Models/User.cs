using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GymManagerWebApp.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        
        [Required]
        [DisplayName]
        public string FirstName { get; protected set; }
        
        [Required]
        public string SurName { get; protected set; }
        
        [Required]
        [Phone]
        public PhoneAttribute PhoneNr { get; protected set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; protected set; }
        
        [Required]
        [PasswordPropertyText]
        public PasswordPropertyTextAttribute Password { get; protected set; }

        [Required]
        [PasswordPropertyText]
        public PasswordPropertyTextAttribute RepeatedPassword { get; protected set; }

        [Required]
        public string Gender { get; set; }
       
        public DateTime CreatedAt { get; protected set; }


    }
}