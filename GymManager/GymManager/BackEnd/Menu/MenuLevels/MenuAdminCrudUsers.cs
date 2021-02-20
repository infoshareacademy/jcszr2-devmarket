using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.BackEnd.Menu.MenuLevels
{
    class MenuAdminCrudUsers : MenuCommonLibrary
    {
        public MenuAdminCrudUsers()
        {
            _positions.Add("Dodaj użytkownika");
            _positions.Add("Usuń użytkownika");
            _positions.Add("Wyświetl wszystkich użytkowników");
            _positions.Add("Usuń użytkownika");
            _positions.Add("Cofnij");
            _positions.Add("Wyjdź z programu");
        }
    }
}

