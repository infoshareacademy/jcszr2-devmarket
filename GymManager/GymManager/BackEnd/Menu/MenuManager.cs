using System;
using System.Collections.Generic;
using GymManager.BackEnd;
using GymManager.BackEnd.Users;

namespace GymManager
{
    public class MenuManager
    {
        private MenuExercises menuExercises;
        private MenuTickets menuTickets = new MenuTickets();
        private MenuStart menuStart = new MenuStart();
        
        public void Run(MenuExercises availableExercises)
        {
            menuExercises = availableExercises;
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
            currentMenu.Print();
            var userChoice = GetMenuNrFromUser();

            if(currentMenu == menuStart)
            {
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuExercises);
                        break;
                    case 2:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuTickets);
                        break;
                    case 3:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        new SignInLogIn().LogIn();
                        break;
                    case 4:
                        PrintUserChoiceConfirmation(currentMenu, userChoice);
                        new SignInLogIn().SignIn();
                        ChangeMenu(menuStart);
                        break;
                    case 5:
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
                var goBackPosition = currentMenu.Positions.Count - 1;
                var exitPosition = currentMenu.Positions.Count ;

                if (userChoice < currentMenu.Positions.Count -3 && userChoice > 0)
                {
                    //ChangeMenu();
                }
                else if(userChoice == goBackPosition )
                {
                    ChangeMenu(menuStart);
                }
                else if (userChoice == exitPosition)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    PrintInvalidTypeDataError();
                    ChangeMenu(currentMenu);
                }
            }
            else if(currentMenu == menuTickets)
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

            Console.WriteLine($"Wybrałeś opcję nr {chosenNr}:" ); //{currentMenu.Positions[]}
        }

    }
}