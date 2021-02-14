using GymManager.BackEnd;
using System.Collections.Generic;

namespace GymManager
{
    public class MenuExercises : MenuCommonLibrary
    {

        public MenuExercises(List<Exercise> availableExercises)
        {
            for (int i = 0; i <= availableExercises.Count; i++)
            {
                try
                {
                    _positions.Add(availableExercises[i].GetExercise());

                }
                catch
                {
                }
            }
            _positions.Add("Wróć do poprzedniego menu");
            _positions.Add("Wyjście z programu");
        }

    }
}