using GymManagerWebApp.Services.Exercises;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Exercises : IExercises
    {
        public IList<Exercise> ListOfExercises = new List<Exercise>();

        public async Task Init()
        {
            var readedListOfExercises = await FileReaders.JsonManager.GetExercisesAsync();

            this.ListOfExercises = readedListOfExercises;
        }
        public IList<Exercise> GetAllExercises()
        {
            return this.ListOfExercises;
        }
    }
}