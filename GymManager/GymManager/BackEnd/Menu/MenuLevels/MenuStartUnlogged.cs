using System.Text;
using GymManager.BackEnd.Users;

namespace GymManager
{
    public class MenuStartUnlogged : MenuCommonLibrary
    {

        public MenuStartUnlogged()
        {

            Positions.Add("Dostępne zajęcia na silowni");
            Positions.Add("Wyświetl zajęcia filtrowane wg kryteriów");
            Positions.Add("Kup karnet");
            Positions.Add("Logowanie");
            Positions.Add("Rejestracja");
            Positions.Add("Wyjście z programu");

        }
    }
}