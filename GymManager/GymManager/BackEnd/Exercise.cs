using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd
{
    public class Exercise
    {
        public string exerciseName;
        public string coachName;
        public DateTime exerciseDate;

        public Exercise(string excercise, DateTime date, string coach)
        {
            exerciseName = excercise;
            exerciseDate = date;
            coachName = coach;
        }
    }
}
