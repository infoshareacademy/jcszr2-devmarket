using GymManagerWebApp.Services.Exercises;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Exercises
    {
        public IList<Exercise> ListOfExercises { get; set; }
        public List<Options> ListOfOptions { get; set; }

        public IList<Exercise> GetAllExercises()
        {
            return this.ListOfExercises;
        }
        public string getHourAndMinutes(int value)
        {
            return value.ToString();
        }
    }
}