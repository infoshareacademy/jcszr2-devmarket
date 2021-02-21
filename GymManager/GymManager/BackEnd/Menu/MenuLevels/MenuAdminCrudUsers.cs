using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd.Menu.MenuLevels
{
    class MenuAdminCrudUsers : MenuCommonLibrary
    {
        public MenuAdminCrudUsers()
        {
            Positions.Add("Dodaj użytkownika");
            Positions.Add("Wyświetl wszystkich użytkowników");
            Positions.Add("Usuń użytkownika");
            Positions.Add("Edytuj użytkownika");
            Positions.Add("Cofnij");
            Positions.Add("Wyjdź z programu");
        }
    }
}

