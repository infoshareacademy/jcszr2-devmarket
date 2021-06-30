using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ActivationDate{ get; set; }
        public bool CanBeCanceled { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual CalendarEvent CalendarEvent { get; set; }
    }
}
