using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd.Menu.MenuLevels.AdminUserMenu
{
    class MenuEditUser : MenuCommonLibrary
    {

        public MenuEditUser()
        {
            Positions.Add("Edytuj login");
            Positions.Add("Edytuj hasło");
            Positions.Add("Edytuj typ konta");
            Positions.Add("Wróć");
            Positions.Add("Wyjdź");
        }
    }
}
