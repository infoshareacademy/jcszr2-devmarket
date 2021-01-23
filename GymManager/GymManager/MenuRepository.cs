using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager
{

    class MenuRepository
    {
        private static Dictionary<int, string> _startMenu = new Dictionary<int, string>()
            {
                {1,"Dostępne zajęcia na silowni"},
                {2,"Kup karnet" },
                {3,"Logowanie" },
                {4,"Rejestracja" },
                {5,"Wyjście z programu" }
            };

        private static Dictionary<int, string> _exercises = new Dictionary<int, string>()
            {
                {1,"Cardio"},
                {2,"Sztuki walki" },
                {3,"Crossfit" },
                {4,"Ćwiczenia siłowe" },
                {5,"Choreograficzne" },
                {6,"Wróć do poprzedniego menu" },
                {7,"Wyjście z programu" },
            };

        private static Dictionary<int, string> _tickets = new Dictionary<int, string>()
            {
                {1,"Karnet jednorazowy"},
                {2,"Karnet tygodniowy" },
                {3,"Karnet miesięczny" },
                {5,"Karnet 3-miesięczny" },
                {6,"Wróć do poprzedniego menu" },
                {7,"Wyjście z programu" },
            };


        public static Dictionary<int, string> StartMenu { get { return _startMenu; } }
        public static Dictionary<int, string> Exercises { get { return _exercises; } }
        public static Dictionary<int, string> Tickets { get { return _tickets; } }

        
        
    }
}
