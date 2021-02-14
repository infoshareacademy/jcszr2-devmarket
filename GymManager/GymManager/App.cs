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
            var fileDataReader = new FileDataReader("\\BackEnd\\Activities\\listOfExercises.json");
            List<Exercise> listOfAvailableExercises = fileDataReader.ReadJsonData();
            new MenuManager(listOfAvailableExercises).Run();
            Console.WriteLine("App is running");
            
        }
    }
}
