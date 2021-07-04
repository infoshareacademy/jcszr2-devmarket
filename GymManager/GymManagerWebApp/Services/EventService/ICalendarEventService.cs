using GymManagerWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services
{
    public interface ICalendarEventService
    {
        Task<List<CalendarEvent>> GetAllEvents();
        Task<CalendarEvent> GetEventByIdAsync(int eventId);
        Task<int> GetEventIdByReservationIdAsync(int reservationId);
        Task IncreaseAvailableVacanciesAsync(int eventId);
        Task ReduceAvailableVacanciesAsync(int eventId);
    }
}