using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd.Menu.MenuLevels
{
    class MenuStartStandardUser : MenuCommonLibrary
    {
        public MenuStartStandardUser() 
        {
            Positions.Add("Dostępne zajęcia na silowni");
            Positions.Add("Wyświetl zajęcia filtrowane wg kryteriów");
            Positions.Add("Kup karnet");
            Positions.Add("Wyloguj");
            Positions.Add("Wyjście z programu");
        }
    }
}
