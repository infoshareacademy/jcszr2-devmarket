using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd
{
    class App
    {
        public void Start()
        {
            Console.WriteLine("App is running");
            var fileDataReader = new FileDataReader("\\BackEnd\\Activities\\listOfExercises.json");
            var listOfAvailableExercises = fileDataReader.ReadJsonData();

        }
    }
}
