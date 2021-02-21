using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.FrontEnd.Menu
{
    class MenuRegister : MenuCommonLibrary
    {
        public MenuRegister()
        {
            Positions.Add("Podaj Login:");
            Positions.Add("Podaj Hasło:");
            Positions.Add("Podaj Email:");
            Positions.Add("Cofnij");
            Positions.Add("Wyjdź");
        }
    }
}
