using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Authorization;
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
        Carnet GetCarnetByNr(int carnetNumber);
        List<Carnet> GetCarnetTypes();
        Task<List<Carnet>> GetPurchasedCarnets(string userEmail, string carnetCategoryName);
        [Authorize("Admin")]
        Task<List<Carnet>> GetPurchasedCarnets(string carnetCategoryName);
        Task<bool> IsAnyActive(string userEmail);
    }
}
