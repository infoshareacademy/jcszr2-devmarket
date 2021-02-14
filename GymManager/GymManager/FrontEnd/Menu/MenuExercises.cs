using GymManager.BackEnd;
using System.Collections.Generic;

namespace GymManager
{
    public class MenuExercises : MenuCommonLibrary
    {
        private List<Exercise> _availableExercises = new List<Exercise>();
        public MenuExercises(List<Exercise> availableExercises)
        {
            int counter = 0;
            for(int i=0; i<=availableExercises.Count;i++)
            {
                try 
                { 
                    _positions.Add(availableExercises[i].GetExercise(), counter);
                    counter++;
                }
                catch
                {
                }
            }

            counter++;
            _positions.Add("Wróć do poprzedniego menu", counter);
            counter++;
            _positions.Add("Wyjście z programu", counter);
        }

        public List<Exercise> GetExercisesList()
        {
            return _availableExercises;
        }
    }

}