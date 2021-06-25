using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Services.CarnetService
{
    public class CarnetService : ICarnetService
    {
        private readonly GymManagerContext _dbContext;

        public CarnetService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Carnet> GetCarnetTypes()
        {
            return  new CarnetsOfferViewModel().CarnetList;
        }

        public Carnet GetCarnetByNr(int carnetNumber)
        {
            var allCarnetTypes = GetCarnetTypes();
            var selectedCarnet = allCarnetTypes.Single(x => x.CarnetTypeNumber == carnetNumber);
            return selectedCarnet;
        }

        public async Task AddCarnetAsync(int carnetTypeNumber, string userEmail)
        {
            var selectedCarnet = GetCarnetByNr(carnetTypeNumber);
            var carnet = new Carnet()
            {
                CarnetTypeNumber = carnetTypeNumber,
                CarnetCategory = selectedCarnet.CarnetCategory,
                Name = selectedCarnet.Name,
                Quantity = selectedCarnet.Quantity,
                Price = selectedCarnet.Price,
                PurchasedAt = DateTime.UtcNow,
                OwnerEmail = userEmail,
                RemainQty = selectedCarnet.Quantity,
                IsActive = false,
            };
            await _dbContext.AddAsync(carnet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Carnet>> GetPurchasedCarnets(string userEmail, string carnetCategoryName)
        {

            var purchasedCarnets = await _dbContext.PurchasedCarnets
                .Where(x => x.CarnetCategory == carnetCategoryName && x.OwnerEmail == userEmail).Select(x => x).ToListAsync();

            return purchasedCarnets;
        }

        [Authorize("Admin")]
        public async Task<List<Carnet>> GetPurchasedCarnets(string carnetCategoryName)
        {
            var purchasedCarnets = await _dbContext.PurchasedCarnets
                .Where(x => x.CarnetCategory == carnetCategoryName).Select(x => x).ToListAsync();

            return purchasedCarnets;
        }

        public async Task<bool> IsAnyActive(string userEmail)
        {
            var anyActive = await _dbContext.PurchasedCarnets.AnyAsync(x=>x.IsActive && x.OwnerEmail == userEmail);
            if (anyActive)
            {
                return true;
            }
            else return false;
        }

        public async Task ActivateCarnet(int carnetId)
        {
                var activatedCarnet = await _dbContext.PurchasedCarnets.FindAsync(carnetId);
                activatedCarnet.IsActive = true;
                activatedCarnet.UsedOn = DateTime.UtcNow;

                if(activatedCarnet.CarnetCategory == "czasowy")
                {
                    activatedCarnet.ExpireDate = DateTime.Today.AddDays(activatedCarnet.Quantity);
                    activatedCarnet.RemainQty = 0;
                }
                else if(activatedCarnet.CarnetCategory == "ilosciowy")
                {
                    activatedCarnet.RemainQty -= 1;
                }
                await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Carnet>> GetActivatedCarnets(string userEmail, string carnetCategoryName)
        {
                var activeCarnets = await _dbContext.PurchasedCarnets
                    .Where(x => x.CarnetCategory == carnetCategoryName && x.OwnerEmail == userEmail && x.IsActive == true).Select(x => x).ToListAsync();

                return activeCarnets;
        }
    }
}

