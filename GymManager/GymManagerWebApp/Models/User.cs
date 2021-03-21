using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace GymManagerWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [Phone]
        public string PhoneNr { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password1 { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password2 { get; set; }

        [Required]
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