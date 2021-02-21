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
            Positions.Add("Podaj dane logowania");
            Positions.Add("Zapomniałem loginu");
            Positions.Add("Zapomniałem Hasła");
            Positions.Add("Cofnij");
            Positions.Add("Wyjdź");
        }
    }
}
