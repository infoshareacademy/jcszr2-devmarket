using GymManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.CarnetService
{
    public interface ICarnetService
    {
        Task ActivateCarnet(int carnetId);
        Task AddCarnetAsync(int carnetId, string userEmail);
        Task<List<Carnet>> GetActivatedCarnets(string userEmail, string carnetCategoryName);
        Task<List<Carnet>> GetPurchasedCarnets(string userEmail, string carnetCategoryName);
        Task<bool> IsAnyActive(string userEmail);
    }
}
