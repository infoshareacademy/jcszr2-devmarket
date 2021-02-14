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
            
            Console.WriteLine("App is running");
            var fileDataReader = new FileDataReader("\\BackEnd\\Activities\\listOfExercises.json");
            var listOfAvailableExercises = fileDataReader.ReadJsonData(); //przekazac do  menumanager
            var listMenuOfAvailableExercises = new MenuExercises(listOfAvailableExercises);
            new MenuManager().Run(listMenuOfAvailableExercises);

        }
    }
}
