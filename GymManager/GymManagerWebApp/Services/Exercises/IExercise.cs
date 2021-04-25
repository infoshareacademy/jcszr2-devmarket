using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Services.Exercises
{
    interface IExercise
    {
        int Id { get; set; }
        string exerciseName { get; set; }
        DateTime exerciseDate { get; set; }
        int exerciseDurationTime { get; set; }
        int exerciseCoachId { get; set; }
    }
}
