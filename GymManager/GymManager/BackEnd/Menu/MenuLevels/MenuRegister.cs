using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.FrontEnd.Menu
{
    class MenuRegister : MenuCommonLibrary
    {
        public MenuRegister()
        {
            _positions.Add("Podaj Login:");
            _positions.Add("Podaj Hasło:");
            _positions.Add("Podaj Email:");
            _positions.Add("Powrót");
            _positions.Add("Wyjście z programu");
        }
    }
}
