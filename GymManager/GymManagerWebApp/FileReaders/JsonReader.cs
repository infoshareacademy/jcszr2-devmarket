using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Newtonsoft.Json;

namespace GymManagerWebApp.FileReaders
{
    public class JsonReader
    {   
        public static string GetUsersFilePath()
        {
            string jsonPathInsideTheProject = "\\BackEnd\\Databases\\Users.json";
            string pathToProject = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var fullPath = pathToProject + "\\Debug\\netcoreapp3.1\\" + jsonPathInsideTheProject;
            return fullPath;
        }

        public List<User> GetUsers()
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            return listOfUsers;
        }


    }
}
