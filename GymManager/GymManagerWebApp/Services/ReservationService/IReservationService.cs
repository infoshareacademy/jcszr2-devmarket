using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.ReservationService
{
    public interface IReservationService
    {
        Task BookEvent(User currentUser, CalendarEvent eventToBook);
    }
}