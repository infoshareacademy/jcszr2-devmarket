using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.ReservationService
{
    public interface IReservationService
    {
        Task ReserveEventAsync(User currentUser, CalendarEvent eventToBook);
        Task<List<Reservation>> GetReservationsByUserAsync(User user);
        Task RemoveReservation(int ReservationId);
    }
}