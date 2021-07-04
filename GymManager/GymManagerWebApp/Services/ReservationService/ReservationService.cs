using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly GymManagerContext _dbContext;

        public ReservationService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BookEvent(User currentUser, CalendarEvent eventToBook)
        {
            var reservation = new Reservation()
            {
                ActivationDate = DateTime.UtcNow,
                CanBeCanceled = true,
                IsActive = true,
                User = currentUser,
                CalendarEvent = eventToBook,
            };

            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

    }
}