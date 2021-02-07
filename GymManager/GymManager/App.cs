using GymManager.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager
{
    class App
    {
        public void Start()
        {
            new MenuManager().Run();
            Console.WriteLine("App is running");
            var fileDataReader = new FileDataReader("\\BackEnd\\Activities\\listOfExercises.json");
            var listOfAvailableExercises = fileDataReader.ReadJsonData();
        }
    }
}
