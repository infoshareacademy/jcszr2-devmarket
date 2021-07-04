using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class CalendarEventViewModel
    {
        public List<CalendarEvent> CalendarEvents {get;set;}
        public List<Reservation> Reservations { get; set; }

    }
}
