using GymManagerWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services
{
    public interface ICalendarEventService
    {
        Task<List<CalendarEvent>> GetAllEvents();
    }
}