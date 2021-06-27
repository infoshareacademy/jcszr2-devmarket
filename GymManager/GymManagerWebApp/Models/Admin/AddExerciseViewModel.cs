using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class AddExerciseViewModel : Controller
    {
        public string ExerciseName { get; set; }
        public string ExerciseDate { get; set; }
        public int ExerciseDurationTimeInMinutes { get; set; }
        public int CoachId { get; set; }
    }
}
