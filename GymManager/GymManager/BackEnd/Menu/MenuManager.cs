using GymManager.FrontEnd.Menu;
using System;
using System.Collections.Generic;
using GymManager.BackEnd;
using GymManager.BackEnd.Menu.MenuLevels;
using GymManager.BackEnd.Menu.MenuLevels.AdminUserMenu;
using GymManager.BackEnd.Users;
using System.Linq;
using System.Threading;

namespace GymManager
{
    public class MenuManager
    {
        private MenuExercises menuExercises;
        private MenuTickets menuTickets = new MenuTickets();
        private MenuStartUnlogged menuStart = new MenuStartUnlogged();
        private MenuEditUser menuEditUser = new MenuEditUser();
        private MenuAdminCrudUsers menuAdminCrudUsers = new MenuAdminCrudUsers();
        private AdminUser adminUser = new AdminUser();
        private MenuStartAdmin menuStartAdmin = new MenuStartAdmin();
        private MenuStartStandardUser menuStartStandardUser = new MenuStartStandardUser();

        private MenuExercisesWithFiltering menuExercisesWithFiltering = new MenuExercisesWithFiltering();

        private List<Exercise> _exerices;


        public MenuManager(List<Exercise> exercises)
        {
            _exerices = exercises;
        }

        public void Run(MenuExercises availableExercises)
        {
            menuExercises = availableExercises;
            PrintGreet();
            ChooseMenu(menuStart);
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
        private void ChooseMenu(MenuCommonLibrary currentMenu)
        {
            Console.Clear();
            currentMenu.Print();
            var userChoice = GetMenuNrFromUser();

            if (User.currentUser == null)
            {
                Console.WriteLine("Przeglądasz stronę jako użytkownik niezalogowany");
                if (currentMenu == menuStart)
                {
                    Console.Clear();
                    switch (userChoice)
                    {
                        case 1:
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuExercises);
                            break;
                        case 2:
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuExercisesWithFiltering);
                            break;
                        case 3:
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuTickets);
                            break;
                        case 4:
                            PrintConfirmation(currentMenu, userChoice);
                            new SignInLogIn().LogIn();
                            if (User.currentUser.IsAdmin)
                            {
                                ChooseMenu(menuStartAdmin);
                            }
                            else
                            {
                                ChooseMenu(menuStartStandardUser);
                            }
                            break;
                        case 5:
                            PrintConfirmation(currentMenu, userChoice);
                            new SignInLogIn().SignIn(false);
                            ChooseMenu(menuStart);
                            break;
                        case 6:
                            PrintConfirmation(currentMenu, userChoice);
                            Environment.Exit(0);
                            break;
                        default:
                            PrintInvalidTypeDataError();
                            ChooseMenu(currentMenu);
                            break;
                    }
                }
                else if (currentMenu == menuExercises)
                {
                    Console.Clear();
                    var goBackPosition = currentMenu.Positions.Count - 1;
                    var exitPosition = currentMenu.Positions.Count;

                    if (userChoice < currentMenu.Positions.Count - 3 && userChoice > 0)
                    {
                        //ChangeMenu();
                    }
                    else if (userChoice == goBackPosition)
                    {
                        ChooseMenu(menuStart);
                    }
                    else if (userChoice == exitPosition)
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        PrintInvalidTypeDataError();
                        ChooseMenu(currentMenu);
                    }
                }
                else if (currentMenu == menuTickets)
                {
                    switch (userChoice)
                    {
                        case 0:
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuTickets);
                            break;
                        case 1:
                            PrintConfirmation(currentMenu, userChoice);
                            //"Karnet jednorazowy"
                            break;
                        case 2:
                            PrintConfirmation(currentMenu, userChoice);
                            //"Karnet tygodniowy"
                            break;
                        case 3:
                            PrintConfirmation(currentMenu, userChoice);
                            //Karnet miesięczny")
                            break;
                        case 4:
                            PrintConfirmation(currentMenu, userChoice);
                            //Karnet 3-miesięczny"
                            break;
                        case 5:
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuStart);
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            PrintInvalidTypeDataError();
                            ChooseMenu(currentMenu);
                            break;
                    }
                }
                else if (currentMenu == menuExercisesWithFiltering)
                {
                    Console.WriteLine("filtering");
                    handleMenuExerciseWithFiltering(userChoice, currentMenu);
                }
            }
            else if(User.currentUser.IsAdmin)
            {
                Console.WriteLine($"Zalogowany jako administrator: {User.currentUser.Email}");
                if (currentMenu == menuStartAdmin)
                {
                    switch (userChoice)
                    {
                        case 1: //dostępne zajęcia na słowni
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuExercises);
                            break;
                        case 2: //zarządzaj użytkownikami
                            PrintConfirmation(currentMenu,userChoice);
                            ChooseMenu(menuAdminCrudUsers);
                            break;
                        case 3: //wyloguj
                            PrintConfirmation(currentMenu, userChoice);
                            new SignInLogIn().LogOut();
                            ChooseMenu(menuStart);
                            break;
                        case 4: //wyjdź
                            Environment.Exit(0);
                            break;
                    }
                }
                else if (currentMenu == menuAdminCrudUsers)
                {
                    switch (userChoice)
                    {
                        case 1: //dodaj użytkownika
                            PrintConfirmation(currentMenu,userChoice);
                            adminUser.CreateUser();
                            ChooseMenu(currentMenu);
                            break;
                        case 2: //wyświetl wszystkich użytkowników
                            PrintConfirmation(currentMenu, userChoice);
                            adminUser.PrintAllUsers();
                            ChooseMenu(currentMenu);
                            break;
                        case 3: //Usuń użytkownika
                            PrintConfirmation(currentMenu, userChoice);
                            adminUser.DeleteUser();
                            break;
                        case 4: //Edytuj użytkownika
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuEditUser);
                            break;
                        case 5: //Cofnij
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(menuStartAdmin);
                            break;
                        case 6: //wyjdź
                            PrintConfirmation(currentMenu, userChoice);
                            Environment.Exit(0);
                            break;;
                        default:
                            PrintInvalidTypeDataError();
                            ChooseMenu(currentMenu);
                            break;
                    }
                }
                if (currentMenu == menuEditUser)
                {
                    switch (userChoice)
                    {
                        case 1: //edytuj login
                            PrintConfirmation(currentMenu,userChoice);
                            adminUser.EditUsername();
                            ChooseMenu(currentMenu);
                            break;
                        case 2: //edytuj hasło
                            PrintConfirmation(currentMenu, userChoice);
                            adminUser.EditPassword();
                            ChooseMenu(currentMenu);
                            break;
                        case 3: //edytuj typ konta
                            adminUser.EditUserRights();
                            PrintConfirmation(currentMenu, userChoice);
                            ChooseMenu(currentMenu);
                            break;
                        case 4: //cofnij
                            PrintConfirmation(currentMenu,userChoice);
                            ChooseMenu(menuAdminCrudUsers);
                            break;
                        case 5: //wyjdź
                            Environment.Exit(0);
                            break;
                        default:
                            PrintInvalidTypeDataError();
                            ChooseMenu(currentMenu);
                            break;
                    }
                }
            }
            else if(!User.currentUser.IsAdmin)
            {
                Console.WriteLine($"Zalogowany jako użytkownik standardowy {User.currentUser.Email}");
            }
        }

        public void handleMenuExerciseWithFiltering(int userChoice, MenuCommonLibrary currentMenu)
        {
           // PrintUserChoiceConfirmation(currentMenu, userChoice);
            switch (userChoice)
            {
                case 1:
                    PrintConfirmation(currentMenu, userChoice);
                    HandleFilteringByDate();

                    ChooseMenu(menuStart);
                    break;
                case 2:
                    PrintConfirmation(currentMenu, userChoice);
                    HandleFilteringByExerciseType();

                    ChooseMenu(menuStart);
                    break;
                case 3:
                    PrintConfirmation(currentMenu, userChoice);
                    HandleFilteringByCoach();

                    ChooseMenu(menuStart);

                    break;
                default:
                    Console.WriteLine("Opcja z poza zakresu, powrót do menu głównego");
                    ChooseMenu(menuStart);
                    break;
            }
        }

        private void HandleFilteringByCoach()
        {
            var filteredExercisesByCoaches = _exerices.GroupBy(x => x.coachName).Select(y => y.First()).ToList();
            for (var i = 0; i < filteredExercisesByCoaches.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filteredExercisesByCoaches.ElementAt(i).coachName}");
            }
            Console.WriteLine("Proszę podaj numer trenera dla którego chciałbyś zobaczyć zajęcia");
            var exerciseNumberByText = Console.ReadLine();

            var exerciseCouchChooseByUser = filteredExercisesByCoaches.ElementAt(Int32.Parse(exerciseNumberByText) - 1).coachName;
            var filteredExercisesByUserChoice =
                _exerices.FindAll(exercise => exercise.coachName == exerciseCouchChooseByUser).ToList();
            Console.Clear();
            for (var i = 0; i < filteredExercisesByUserChoice.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {filteredExercisesByUserChoice.ElementAt(i).exerciseName} {filteredExercisesByUserChoice.ElementAt(i).exerciseDate.ToLongDateString()}");
            }


            Console.WriteLine("");
            Console.WriteLine("Przyciśnij jakiś klawisz aby wrócić do menu głównego");
            Console.ReadKey();
        }

        private void HandleFilteringByExerciseType()
        {
            var filteredExercises = _exerices.GroupBy(x => x.exerciseName).Select(y => y.First()).ToList();
            for (var i = 0; i < filteredExercises.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {filteredExercises.ElementAt(i).exerciseName}");
            }
            Console.WriteLine("Proszę podaj numer zadania dla którego chciałbyś zobaczyć dostępne daty");
            var exerciseNumberByText = Console.ReadLine();
            var exerciseNameChooseByUser = filteredExercises.ElementAt(Int32.Parse(exerciseNumberByText) - 1).exerciseName;
            var filteredExercisesByUserChoice =
                _exerices.FindAll(exercise => exercise.exerciseName == exerciseNameChooseByUser).ToList();
            Console.Clear();
            for (var i = 0; i < filteredExercisesByUserChoice.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {filteredExercisesByUserChoice.ElementAt(i).exerciseName} {filteredExercisesByUserChoice.ElementAt(i).exerciseDate.ToLongDateString()}");
            }


            Console.WriteLine("");
            Console.WriteLine("Przyciśnij jakiś klawisz aby wrócić do menu głównego");
            Console.ReadKey();

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
            Console.WriteLine("Błąd, wprowadzono błędne dane z poza zakresu, lub podany format jest nieprawidłowy. Spróbuj ponownie\n\n");
        }
        private void PrintConfirmation(MenuCommonLibrary currentMenu, int chosenNr)
        {
            Console.WriteLine($"Wybrałeś opcję nr {chosenNr}: {currentMenu.Positions[chosenNr-1]}" ); 
        }
    }
}