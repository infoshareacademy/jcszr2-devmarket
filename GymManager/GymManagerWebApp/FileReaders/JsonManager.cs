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

        public static IList<User> GetUsers()
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            return listOfUsers;
        }
        
        public static void AddUser(User user)
        {
            var listOfUsers = GetUsers();
            listOfUsers.Add(user);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(GetUsersFilePath(), updatedJson);
        }
    }
}
