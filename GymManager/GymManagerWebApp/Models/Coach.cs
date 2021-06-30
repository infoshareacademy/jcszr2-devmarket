using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Coach : User
    {
        public virtual IList<Exercise> Exercises { get; set; } = new List<Exercise>();
        public virtual IList<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();
    }
}
