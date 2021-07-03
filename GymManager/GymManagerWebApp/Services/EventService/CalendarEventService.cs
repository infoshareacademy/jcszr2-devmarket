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
    }
}
