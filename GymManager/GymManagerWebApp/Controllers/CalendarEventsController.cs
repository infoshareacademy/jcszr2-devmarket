using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;

namespace GymManagerWebApp.Controllers
{
    public class CalendarEventsController : Controller
    {
        private readonly ICalendarEventService _calendarService; 
        public CalendarEventsController(ICalendarEventService calendarEventService)
        {
            _calendarService = calendarEventService;
        }

        [HttpGet]
        public async Task<IActionResult> AvailableEvents()
        {
            var model = new CalendarEventViewModel();
            model.CalendarEvents = await _calendarService.GetAllEvents();
            return View(model);
        }
    }
}
