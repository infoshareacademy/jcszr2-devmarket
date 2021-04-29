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
        public async Task AddCarnetAsync(int carnetId, string currentUsername)
        {
            using (var context = new GymManagerContext())
            {
                var carnets = new CarnetViewModel().CarnetList;
                var chosenCarnet = carnets.Single(x => x.Id == carnetId);

                if(chosenCarnet.GetType().Name == "TimeCarnet")
                {
                    var carnet = new TimeCarnet()
                    {
                        Id = carnetId,
                        Name = chosenCarnet.Name,
                        Quantity = chosenCarnet.Quantity,
                        Price = chosenCarnet.Price,
                        PurchasedAt = DateTime.UtcNow,
                        OwnerEmail = currentUsername,

                    };

                    await context.AddAsync(carnet);
                    await context.SaveChangesAsync();
                }
                else
                {
                    var carnet = new QuantityCarnet()
                    {
                        Id = carnetId,
                        Name = chosenCarnet.Name,
                        Quantity = chosenCarnet.Quantity,
                        Price = chosenCarnet.Price,
                        PurchasedAt = DateTime.UtcNow,
                        OwnerEmail = currentUsername
                    };

                    await context.AddAsync(carnet);
                    await context.SaveChangesAsync();
                }

            }
        }
       
        //public List<TimeCarnet> GetPurchasedTimeCarnets(string username)
        //{

        //}

        //public List<TimeCarnet> GetPurchasedQuantityCarnets(string username)
        //{

        //}
    }
}
