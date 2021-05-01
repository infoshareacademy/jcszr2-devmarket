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

        public async Task AddCarnetAsync(int carnetTypeNumber, string currentUsername)
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
                    OwnerEmail = currentUsername,
                    RemainQty = selectedCarnet.Quantity,
                };

                await context.AddAsync(carnet);
                await context.SaveChangesAsync();
            }

        }

        public async Task<List<Carnet>> GetPurchasedCarnets(string currentUserEmail, string carnetCategoryName)
        {
            using (var context = new GymManagerContext())
            {
                var timeCarnets = await context.PurchasedCarnets
                    .Where(x => x.CarnetCategory == carnetCategoryName && x.OwnerEmail == currentUserEmail).Select(x => x).ToListAsync();

                return timeCarnets;
            }
        }
    }
}

