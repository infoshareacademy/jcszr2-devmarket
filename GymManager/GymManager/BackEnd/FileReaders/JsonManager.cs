using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GymManager.BackEnd.Users;
using Newtonsoft.Json;

namespace GymManager.BackEnd
{
    class JsonManager
    {


        public string GetUsersFilePath()
        {
            string jsonPathInsideTheProject = "\\BackEnd\\Users\\listOfUsers.json";
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

        public void addUser(User user)
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            listOfUsers.Add(user);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
        public void RemoveUser(string loginToDelete)
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            listOfUsers.RemoveAll(login => login.Email== loginToDelete);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        public void UpdateUserPassword(string loginToEdit, string newPassword)
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            listOfUsers.Where(login => login.Email == loginToEdit).Select(password => password.Password == newPassword);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        public void UpdateUserEmail(string loginToEdit, string newLogin)
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            listOfUsers.Where(login => login.Email == loginToEdit).Select(login => login.Email == newLogin);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        public void UpdateUserRights(string loginToEdit, bool adminRights)
        {
            var filePath = GetUsersFilePath();
            var listOfUsers = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(filePath));
            listOfUsers.Where(login => login.Email == loginToEdit).Select(rights => rights.IsAdmin== adminRights);
            var updatedJson = JsonConvert.SerializeObject(listOfUsers, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

    }
}
