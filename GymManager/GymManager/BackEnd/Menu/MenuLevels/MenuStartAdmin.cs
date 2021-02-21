using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd.Menu.MenuLevels
{
    class MenuStartAdmin : MenuCommonLibrary
    {
        public MenuStartAdmin()
        {
            Positions.Add("Dostępne zajęcia na silowni");
            Positions.Add("Zarządzaj użytkownikami");
            Positions.Add("Wyloguj");
            Positions.Add("Wyjście z programu");
        }
    }
}
