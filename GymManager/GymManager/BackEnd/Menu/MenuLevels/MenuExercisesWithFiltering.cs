using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.FrontEnd.Menu
{
    class MenuExercisesWithFiltering : MenuCommonLibrary
    {
        public MenuExercisesWithFiltering()
        {
            Positions.Add("Dostępne zajęcia na silowni, filtrowane po dacie i godzinie");
            Positions.Add("Dostępne zajęcia na silowni, filtrowane po typie zajęć");
            Positions.Add("Dostępne zajęcia na silowni, filtrowane wg prowadzącego");
            Positions.Add("Wyjście do menu głównego");
        }
    }
}
