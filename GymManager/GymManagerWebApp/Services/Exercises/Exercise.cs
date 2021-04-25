using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.Exercises
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDate { get; set; }
        public int ExerciseDurationTime { get; set; }
        public int ExerciseCoachId { get; set; }
    }
}
