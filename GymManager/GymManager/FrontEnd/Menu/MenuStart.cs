using System.Text;

namespace GymManager
{


    public class MenuStart : MenuCommonLibrary
    {
        public MenuStart()
        {
            _positions.Add(1, "Dostępne zajęcia na silowni");
            _positions.Add(2, "Kup karnet");
            _positions.Add(3, "Logowanie");
            _positions.Add(4, "Rejestracja");
            _positions.Add(5, "Wyjście z programu");
        }
    }

}