using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
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
            var listOfUsers =  await Task.Run(()=>JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath)));
            listOfUsers = listOfUsers.ToList();
            return listOfUsers;
        }
        
        public static async Task AddUserAsync(User user)
        {
            var listOfUsers = await  GetUsersAsync();
            listOfUsers.Add(user);
            var updatedJson = await Task.Run(()=>JsonConvert.SerializeObject(listOfUsers, Formatting.Indented));
            File.WriteAllText(GetUsersFilePath().ToString(), updatedJson);
        }

        
    }
}
