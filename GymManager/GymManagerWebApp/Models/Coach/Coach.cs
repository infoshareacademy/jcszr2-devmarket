using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public string CoachSurname { get; set; }

        public Coach()
        {
        }
        public Coach(string coachName, string coachSurName)
        {
            CoachName = coachName;
            CoachSurname = coachSurName;
        }
    }
}
