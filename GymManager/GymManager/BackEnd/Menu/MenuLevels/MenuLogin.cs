using System;
using System.Collections.Generic;
using System.Text;
using GymManager.BackEnd.Users;

namespace GymManager.FrontEnd.Menu
{
    class MenuLogin : MenuCommonLibrary
    {
        public MenuLogin()
        {
            _positions.Add("Podaj dane logowania");
            _positions.Add("Zapomniałem loginu");
            _positions.Add("Zapomniałem Hasła");
            _positions.Add("Powrót");
            _positions.Add("Wyjście");
        }
    }
}
