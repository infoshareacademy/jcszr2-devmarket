using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace GymManagerWebApp.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string PhoneNumber { get; set; }
        public override string Email { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public static object Identity { get; internal set; }

        public User()
        {
        }

        public User(string firstName, string lastName, string email, string phoneNr, string gender, DateTime createdAt)
        {
            FirstName = firstName;
            LastName= lastName;
            Email = email;
            PhoneNumber = phoneNr;
            Gender = gender;
            CreatedAt = createdAt;
        }
    }
}