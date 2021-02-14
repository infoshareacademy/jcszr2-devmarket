using System.Text;

namespace GymManager
{

    public class MenuStart : MenuCommonLibrary
    {
        public MenuStart()
        {
            _positions.Add("Dostępne zajęcia na silowni",1);
            _positions.Add("Kup karnet", 2);
            _positions.Add("Logowanie", 3);
            _positions.Add("Rejestracja",4);
            _positions.Add("Wyjście z programu",5);
        }
    }

}