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
                    Positions.Add(availableExercises[i].GetExercise());

                }
                catch
                {
                }
            }
            Positions.Add("Cofnij");
            Positions.Add("Wyjdź");
        }

    }
}