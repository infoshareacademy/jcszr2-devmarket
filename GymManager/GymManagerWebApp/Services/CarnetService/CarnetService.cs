using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymManagerWebApp.Services.CarnetService
{
    public class CarnetService : ICarnetService
    {
        public async Task AddCarnetAsync(int carnetTypeNumber, string userEmail)
        {
            using (var context = new GymManagerContext())
            {
                var allCarnetTypes = new CarnetsOfferViewModel().CarnetList;
                var selectedCarnet = allCarnetTypes.Single(x => x.CarnetTypeNumber == carnetTypeNumber); //getting right carnet type object from carnet list modelview
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
                await context.AddAsync(carnet);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Carnet>> GetPurchasedCarnets(string userEmail, string carnetCategoryName)
        {
            using (var context = new GymManagerContext())
            {
                var purchasedCarnets = await context.PurchasedCarnets
                    .Where(x => x.CarnetCategory == carnetCategoryName && x.OwnerEmail == userEmail).Select(x => x).ToListAsync();

                return purchasedCarnets;
            }
        }


        public async Task<bool> IsAnyActive(string userEmail)
        {
            using (var context = new GymManagerContext())
            {
                var anyActive = await context.PurchasedCarnets.AnyAsync(x=>x.IsActive && x.OwnerEmail == userEmail);
                if (anyActive)
                {
                    return true;
                }
                else return false;
            }
        }

        public async Task ActivateCarnet(int carnetId)
        {
            using (var context = new GymManagerContext())
            {
                var activatedCarnet = await context.PurchasedCarnets.FindAsync(carnetId);
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
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Carnet>> GetActivatedCarnets(string userEmail, string carnetCategoryName)
        {
            using (var context = new GymManagerContext())
            {
                var activeCarnets = await context.PurchasedCarnets
                    .Where(x => x.CarnetCategory == carnetCategoryName && x.OwnerEmail == userEmail && x.IsActive == true).Select(x => x).ToListAsync();

                return activeCarnets;
            }
        }
    }
}

