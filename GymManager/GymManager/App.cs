using GymManager.BackEnd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GymManager.BackEnd.Users;
using Newtonsoft.Json;

namespace GymManager
{
    class App
    {
        public void Start()
        {

            
            Console.WriteLine("App is running\n");
            var fileDataReader = new BackEnd.FileDataReader("\\BackEnd\\Activities\\listOfExercises.json");
            var listOfAvailableExercises = fileDataReader.ReadJsonData(); 
            var listMenuOfAvailableExercises = new MenuExercises(listOfAvailableExercises);
            new GymManager.MenuManager(listOfAvailableExercises).Run(listMenuOfAvailableExercises);
        }
    }
}
