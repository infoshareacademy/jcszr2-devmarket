using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd
{
    public class Exercise
    {
        private string exerciseName;
        private DateTime exerciseDate;

        public Exercise(string excercise, DateTime date)
        {
            exerciseName = excercise;
            exerciseDate = date;
        }

        public string GetExercise()
        {
            return exerciseName;
        }
    }
}
