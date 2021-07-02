using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models.Exercises
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDate { get; set; }
        public int ExerciseDurationTimeInMinutes { get; set; }

        public int CoachId { get; set; }
        public List<Coach> CoachList { get; set; }

    }
}
