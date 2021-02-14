using System.Text;

namespace GymManager
{

    public class MenuStart : MenuCommonLibrary
    {
        public MenuStart()
        {
            _positions.Add("Dostępne zajęcia na silowni");
            _positions.Add("Kup karnet");
            _positions.Add("Logowanie");
            _positions.Add("Rejestracja");
            _positions.Add("Wyjście z programu");
        }
    }

}