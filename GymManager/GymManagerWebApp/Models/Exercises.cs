using GymManagerWebApp.Services.Exercises;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Exercises : IExercises
    {
        public IList<Exercise> ListOfExercises { get; set; }
        public List<Options> ListOfOptions = new List<Options> {
            new Options { OptionName = "", OptionValue = 0 },
            new Options { OptionName = "Opcja pierwsza", OptionValue = 1 },
            new Options { OptionName = "Opcja druga", OptionValue = 2 },
            new Options { OptionName = "Opcja trzecia", OptionValue = 3 },
            new Options { OptionName = "Opcja czwarta", OptionValue = 4 },
        };

        public async Task Init()
        {
            var readedListOfExercises = await FileReaders.JsonManager.GetExercisesAsync();

            this.ListOfExercises = readedListOfExercises;
        }
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