using System;
using System.ComponentModel.DataAnnotations;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Services
{
    public interface IUserService
    {
        public void RegisterUser(User userFormData, Guid id, DateTime createdAt, string rights);
    }
}