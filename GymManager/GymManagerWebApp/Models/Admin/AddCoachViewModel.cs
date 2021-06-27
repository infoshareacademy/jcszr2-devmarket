using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class AddCoachViewModel
    {
        public string CoachName { get; set; }
        public string CoachSurName { get; set; }
        public AddCoachViewModel(string coachName, string coachSurName)
        {
            CoachName = coachName;
            CoachSurName = coachSurName;
        }
        public AddCoachViewModel()
        {
        }
    }
}
