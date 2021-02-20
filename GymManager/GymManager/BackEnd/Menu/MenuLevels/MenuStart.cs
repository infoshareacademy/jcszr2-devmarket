using System.Text;
using GymManager.BackEnd.Users;

namespace GymManager
{
    public class MenuStart : MenuCommonLibrary
    {
     
        public MenuStart()
        {
            if ( User.currentUser==null)
            {
                _positions.Add("Dostępne zajęcia na silowni");
                _positions.Add("Kup karnet");
                _positions.Add("Logowanie");
                _positions.Add("Rejestracja");
                _positions.Add("Wyjście z programu");
            }

            else if (User.currentUser.IsAdmin)
            {
                _positions.Add("Dostępne zajęcia na silowni");
                _positions.Add("Zarządzaj użytkownikami");
                _positions.Add("Wyloguj");
                _positions.Add("Wyjście z programu");
            }
            else if (!User.currentUser.IsAdmin)
            {
                _positions.Add("Dostępne zajęcia na silowni");
                _positions.Add("Kup karnet");
                _positions.Add("Wyloguj");
                _positions.Add("Wyjście z programu");
            }
        }
    }
}