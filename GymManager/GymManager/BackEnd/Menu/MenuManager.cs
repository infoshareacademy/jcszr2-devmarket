using GymManager.FrontEnd.Menu;
using System;
using System.Collections.Generic;
using GymManager.BackEnd;

namespace GymManager
{
    public class MenuManager
    {
        private MenuExercises menuExercises = new MenuExercises();
        private MenuTickets menuTickets = new MenuTickets();
        private MenuStart menuStart = new MenuStart();
        private MenuExercisesWithFiltering menuExercisesWithFiltering = new MenuExercisesWithFiltering();

        private List<Exercise> _exerices;


        public MenuManager(List<Exercise> exercises)
        {
            _exerices = exercises;
        }

        public void Run()
        {
            PrintGreet();
            ChangeMenu(menuStart);
        }
        private void PrintGreet()
        {
            Console.WriteLine("Witamy na naszej stronie !\nZapoznaj sie z dostepnymi opcjami :)\n");
        }
        private Int16 GetMenuNrFromUser()
        {
            Console.WriteLine("\nWpisz nr z menu i wciśnij enter aby przejść dalej\n\n");
            Int16.TryParse(Console.ReadLine(), out Int16 chosenNr);
            return chosenNr;
        }
        private void ChangeMenu(MenuCommonLibrary currentMenu)
        {
            Console.Clear();
            currentMenu.Print();
            var userChoice = GetMenuNrFromUser();

            if (currentMenu == menuStart)
            {
                switch (userChoice)
                {
                    case 1:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuExercises);
                        break;
                    case 2:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuExercisesWithFiltering);
                        break;
                    case 3:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuTickets);
                        break;
                    case 4:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        //Login
                        break;
                    case 5:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        //Register
                        break;
                    case 6:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        Environment.Exit(0);
                        break;
                    default:
                        PrintInvalidTypeDataError();
                        ChangeMenu(currentMenu);
                        break;
                }
            }
            else if (currentMenu == menuExercises)
            {
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        // Cardio
                        break;
                    case 2:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        // Sztuki walki
                        break;
                    case 3:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        // Crossfit
                        break;
                    case 4:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        // Ćwiczenia siłowe
                        break;
                    case 5:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        // Choreograficzne
                        break;
                    case 6:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        // Powrót do poprzedniego menu
                        ChangeMenu(menuStart);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        PrintInvalidTypeDataError();
                        ChangeMenu(currentMenu);
                        break;
                }
            }
            else if (currentMenu == menuTickets)
            {
                switch (userChoice)
                {
                    case 0:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuTickets);
                        break;
                    case 1:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        //"Karnet jednorazowy"
                        break;
                    case 2:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        //"Karnet tygodniowy"
                        break;
                    case 3:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        //Karnet miesięczny")
                        break;
                    case 4:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        //Karnet 3-miesięczny"
                        break;
                    case 5:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuStart);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        PrintInvalidTypeDataError();
                        ChangeMenu(currentMenu);
                        break;
                }
            }
            else if (currentMenu == menuExercisesWithFiltering)
            {
                handleMenuExerciseWithFiltering(userChoice, currentMenu); // here need to handle the menu EXERCISES WITH FILTERING
            }
        }

        public void handleMenuExerciseWithFiltering(int userChoice, MenuCommonLibrary currentMenu)
        {
            PrintUserChoiceConfirmation(currentMenu, userChoice);
            switch (userChoice)
            {
                case 1:
                    PrintUserChoiceConfirmation(currentMenu, userChoice);
                    HandleFilteringByDate();

                    ChangeMenu(menuStart);
                    break;
                case 2:
                    PrintUserChoiceConfirmation(currentMenu, userChoice);
                    // here we need to filter by exercise type
                    //"Karnet tygodniowy"
                    break;
                case 3:
                    PrintUserChoiceConfirmation(currentMenu, userChoice);
                    // filter by coach
                    //Karnet miesięczny")
                    break;
                case 4:
                    ChangeMenu(menuStart);
                    break;
                default:
                    Console.WriteLine("Opcja z poza zakresu, powrót do menu głównego");
                    ChangeMenu(menuStart);
                    break;
            }
        }

        private void HandleFilteringByDate()
        {
            Console.WriteLine("Handle filtering by Date");
            Console.WriteLine("Podaj datę początkową w formacie DD/MM/YYYY");
            var beginningDate = Console.ReadLine();
            Console.WriteLine("Podaj datę końcową w formacie DD/MM/YYYY");
            var endDate = Console.ReadLine();
            string[] beginingDateRange = BackEnd.FileDataReader.getDateConvertedToArray(beginningDate);
            string[] endDateRange = BackEnd.FileDataReader.getDateConvertedToArray(endDate);
            var beginningDateToCompare = new DateTime(
                Int32.Parse(beginingDateRange[2]), // year
                Int32.Parse(beginingDateRange[1]), // month
                Int32.Parse(beginingDateRange[0]) // day
            );
            var endDateToCompare = new DateTime(
                Int32.Parse(endDateRange[2]), // year
                Int32.Parse(endDateRange[1]), // month
                Int32.Parse(endDateRange[0]) // day
            );

            List<Exercise> filteredList = new List<Exercise>();

            foreach (var exercise in _exerices)
            {
                int isAfterBeginingDate = DateTime.Compare(beginningDateToCompare, exercise.exerciseDate);
                int isBeforeEndDate = DateTime.Compare(exercise.exerciseDate, endDateToCompare);
                Console.WriteLine($"isAfterBeginingDate:{isAfterBeginingDate}");
                Console.WriteLine($"isBeforeEndDate:{isBeforeEndDate}");
                if (isAfterBeginingDate < 0 && isBeforeEndDate < 0)
                {
                    filteredList.Add(exercise);
                }


            }

            Console.WriteLine("Lista zajęć która znajduje się w zakresie dat:");
            Console.WriteLine($"OD: {beginningDate}");
            Console.WriteLine($"DO: {endDate}");
            foreach (var filteredExercise in filteredList)
            {
                Console.WriteLine($"Nazwa zajęcia{filteredExercise.exerciseName}, data: {filteredExercise.exerciseDate.ToLongDateString()}");
            }
            Console.WriteLine("");
            Console.WriteLine("Przyciśnij jakiś klawisz aby wrócić do menu głównego");
            Console.ReadKey();

        }

        private void PrintInvalidTypeDataError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Błąd, wprowadzono błędne dane z poza zakresu, lub podany format jest nieprawidłowy. Spróbuj ponownie\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintUserChoiceConfirmation(MenuCommonLibrary currentMenu, int chosenNr)
        {
            Console.WriteLine($"Wybrałeś opcję nr {chosenNr}: {currentMenu.Positions[chosenNr]}");
        }

    }
}