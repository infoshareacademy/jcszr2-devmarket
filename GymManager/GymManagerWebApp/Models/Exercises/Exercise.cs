
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDate { get; set; }
        public int ExerciseDurationTimeInMinutes { get; set; }
        public Coach Coach { get; set; }
    }
}
