using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public Reservation(DateTime activationDate, bool canBeCanceled, bool isActive, User user, CalendarEvent calendarEvent)
        {
            ActivationDate = activationDate;
            CanBeCanceled = canBeCanceled;
            IsActive = isActive;
            User = user;
            CalendarEvent = calendarEvent;
        }

        public int Id { get; set; }
        public DateTime ActivationDate{ get; set; }
        public bool CanBeCanceled { get; set; }
        public bool IsActive { get; set; }
        public virtual User  User{ get; set; }
        public virtual CalendarEvent CalendarEvent { get; set; }

    }
}
