using System.Text;

namespace GymManager
{


    public class MenuStart : MenuCommonLibrary
    {
        public MenuStart()
        {
            _positions.Add(1, "Dostępne zajęcia na silowni");
            _positions.Add(2, "Wyświetl zajęcia filtrowane wg kryteriów");
            _positions.Add(3, "Kup karnet");
            _positions.Add(4, "Logowanie");
            _positions.Add(5, "Rejestracja");
            _positions.Add(6, "Wyjście z programu");
        }
    }

}