using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.Exercises;


using Newtonsoft.Json;

namespace GymManagerWebApp.FileReaders
{
    public class JsonManager
    {
        public static string GetUsersFilePath()
        {
            string jsonPathInsideTheProject = "\\Databases\\Users.json";
            string pathToProject = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var fullPath = pathToProject + "\\GymManager\\GymManagerWebApp\\bin\\Debug\\netcoreapp3.1\\" + jsonPathInsideTheProject;
            return fullPath;
        }
        public static async Task<IList<User>> GetUsersAsync()
        {
            var filePath = GetUsersFilePath();
            return await Task.Run(() => JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath)));
        }
        public static async Task AddUserAsync(User user)
        {
            var listOfUsers = await GetUsersAsync();
            listOfUsers.Add(user);
            var updatedJson = await Task.Run(() => JsonConvert.SerializeObject(listOfUsers, Formatting.Indented));
            File.WriteAllText(GetUsersFilePath().ToString(), updatedJson);
        }

        private static string GetExerciseFilePath()
        {
            string jsonPathInsideTheProject = "Databases\\Exercises.json";
            string pathToProject = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var fullPath = pathToProject + "\\GymManager\\GymManagerWebApp\\bin\\Debug\\netcoreapp3.1\\" + jsonPathInsideTheProject;
            return fullPath;
        }
        public static async Task<IList<Exercise>> GetExercisesAsync()
        {
            var filePath = GetExerciseFilePath();
            return await Task.Run(() => JsonConvert.DeserializeObject<List<Exercise>>(File.ReadAllText(filePath)));
        }

        public static async Task AddExercise(Exercise exercise)
        {
            var listOfExercises = await GetExercisesAsync();
            listOfExercises.Add(exercise);
            var updatedJson = await Task.Run(() => JsonConvert.SerializeObject(listOfExercises, Formatting.Indented));
            File.WriteAllText(GetExerciseFilePath().ToString(), updatedJson);
        }

    }

}
