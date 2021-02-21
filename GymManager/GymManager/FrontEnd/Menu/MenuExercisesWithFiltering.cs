using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.FrontEnd.Menu
{
    class MenuExercisesWithFiltering : MenuCommonLibrary
    {
        public MenuExercisesWithFiltering()
        {
            _positions.Add( "Dostępne zajęcia na silowni, filtrowane po dacie i godzinie");
            _positions.Add("Dostępne zajęcia na silowni, filtrowane po typie zajęć");
            _positions.Add( "Dostępne zajęcia na silowni, filtrowane wg prowadzącego");
            _positions.Add( "Wyjście do menu głównego");
        }
    }
}
