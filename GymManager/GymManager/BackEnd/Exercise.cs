using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd
{
    public class Exercise
    {
        public string exerciseName;
        public DateTime exerciseDate;

        public Exercise(string excercise, DateTime date)
        {
            exerciseName = excercise;
            exerciseDate = date;
        }
    }
}
