using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GymManager.BackEnd.Users;
using Newtonsoft.Json;

namespace GymManager.BackEnd
{
    class JsonReader
    {
        public string getUsersFilePath()
        {
            string jsonPathInsideTheProject = "\\BackEnd\\Users\\listOfUsers.json";
            string pathToProject = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var fullPath = pathToProject + "\\Debug\\netcoreapp3.1\\" + jsonPathInsideTheProject;
            return fullPath;
        }

        public void addUser(User user)
        {
            var filePath = getUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            listOfUsers.Add(user);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
        public List<User> readUsers()
        {
            var filePath = getUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            return listOfUsers;
        }

    }
}
