
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagerWebApp
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDate { get; set; }
        public int ExerciseDurationTimeInMinutes { get; set; }

        public int CoachId { get; set; }

        public Exercise()
        {
        }
        public Exercise(string exerciseName, string exerciseDate, int exerciseDurationInMinutesa, int coachId )
        {
            ExerciseName = exerciseName;
            ExerciseDate = exerciseDate;
            ExerciseDurationTimeInMinutes = exerciseDurationInMinutesa;
            CoachId = coachId;
        }
    }
}
