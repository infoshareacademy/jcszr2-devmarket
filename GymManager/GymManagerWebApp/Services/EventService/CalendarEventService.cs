using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services
{
    public class CalendarEventService : ICalendarEventService
    {
        private readonly GymManagerContext _dbContext;

        public CalendarEventService(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CalendarEvent>> GetAllEvents()
        {
            var events = await _dbContext.CalendarEvents
               .Include(m => m.Exercise)
               .Include(m => m.Coach)
               .Include(m => m.Room)
               .ToListAsync();
            return events;
        }

        public async Task<CalendarEvent> GetEventByIdAsync(int eventId)
        {
            return await _dbContext.CalendarEvents.SingleAsync(x=>x.Id == eventId);
        }

        public async Task IncreaseAvailableVacanciesAsync(int eventId)
        {
            var selectedEvent = await _dbContext.CalendarEvents.FindAsync(eventId);
            selectedEvent.VacanciesLeft += 1;
            await _dbContext.SaveChangesAsync();
        }
    
        public async Task ReduceAvailableVacanciesAsync(int eventId)
        {
            var selectedEvent = await _dbContext.CalendarEvents.FindAsync(eventId);
            selectedEvent.VacanciesLeft -= 1;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetEventIdByReservationIdAsync(int reservationId)
        {
            var reservation = await _dbContext.Reservations
                .Where(m => m.Id == reservationId)
                .Include(m => m.CalendarEvent)
                .SingleAsync();

            var eventId = reservation.CalendarEvent.Id;

            return eventId;
        }
    }
}
