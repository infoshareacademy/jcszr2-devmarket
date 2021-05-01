using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.CarnetService
{
    public interface ICarnetService
    {
        Task AddCarnetAsync(int carnetId, string currentUsername);
        Task<List<Carnet>> GetPurchasedCarnets(string currentUserEmail, string carnetCategoryName);
    }
}
