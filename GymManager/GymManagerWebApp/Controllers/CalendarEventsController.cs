using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.ReservationService;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GymManagerWebApp.Controllers
{
    public class CalendarEventsController : Controller
    {
        private readonly ICalendarEventService _calendarEventService;
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        public CalendarEventsController(ICalendarEventService calendarEventService, IReservationService reservationService, UserManager<User> userManager, IUserService userService)
        {
            _calendarEventService = calendarEventService;
            _reservationService = reservationService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> AvailableEvents()
        {
            var model = new CalendarEventViewModel();
            model.CalendarEvents = await _calendarEventService.GetAllEvents();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookEvent(int eventId)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userService.GetUserByIdAsync(currentUserId);
            var selectedEvent = await _calendarEventService.GetEventById(eventId);

            await _reservationService.BookEvent(currentUser, selectedEvent);

            return View("Confirmations/BookEventConfirmation");
        }

    }
}
