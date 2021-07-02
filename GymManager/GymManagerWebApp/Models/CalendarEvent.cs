using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public int VacanciesLeft { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Room Room { get; set; }
    }
}
