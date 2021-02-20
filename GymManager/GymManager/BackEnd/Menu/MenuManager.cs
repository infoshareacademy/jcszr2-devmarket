using System;
using System.Collections.Generic;
using GymManager.BackEnd;
using GymManager.BackEnd.Menu.MenuLevels.AdminUserMenu;
using GymManager.BackEnd.Users;

namespace GymManager
{
    public class MenuManager
    {
        private MenuExercises menuExercises;
        private MenuTickets menuTickets = new MenuTickets();
        private MenuStart menuStart = new MenuStart();
        private MenuEditUser menuEditUser = new MenuEditUser();
        public void Run(MenuExercises availableExercises)
        {
            Console.WriteLine("Witamy na naszej stronie !\nZapoznaj sie z dostepnymi opcjami :)\n");
            menuExercises = availableExercises;
            ChangeMenu(menuStart);
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

            if (currentMenu == menuStart)
            {
                Console.Clear();
                if (User.currentUser == null)
                {
                    switch (userChoice)
                    {
                        case 1:
                            PrintConfirmation(currentMenu, userChoice);
                            ChangeMenu(menuExercises);
                            break;
                        case 2:
                            PrintConfirmation(currentMenu, userChoice);
                            ChangeMenu(menuTickets);
                            break;
                        case 3:
                            PrintConfirmation(currentMenu, userChoice);
                            new SignInLogIn().LogIn();
                            var loggedMenuMode = new MenuStart();
                            ChangeMenu(loggedMenuMode);
                            break;
                        case 4:
                            PrintConfirmation(currentMenu, userChoice);
                            new SignInLogIn().SignIn();
                            ChangeMenu(menuStart);
                            break;
                        case 5:
                            PrintConfirmation(currentMenu, userChoice);
                            Environment.Exit(0);
                            break;
                        default:
                            PrintInvalidTypeDataError();
                            ChangeMenu(currentMenu);
                            break;
                    }
                }
                else
                {
                    if (User.currentUser.IsAdmin)
                    {
                        AdminUser adminUser = new AdminUser();
                        switch (userChoice)
                        {
                            case 1:  //Dodaj użytkownika
                                adminUser.CreateUser();
                                break;
                            case 2: //Usuń użytkownika
                                //adminUser.DeleteUser();
                                break;
                            case 3:  //Edytuj użytkownika
                                adminUser.UpdateUser();
                                break;
                            case 4: //Wyświetl wszystkich użytkowników
                                adminUser.ReadAllUsers();
                                break;
                            case 5: //"Cofnij"
                                ChangeMenu(menuStart);
                                break;
                            case 6: //"Wyjdź z programu"
                                System.Environment.Exit(0);
                                break;
                            default:
                                PrintInvalidTypeDataError();
                                ChangeMenu(currentMenu);
                                break;
                        }
                    }

                    if (!User.currentUser.IsAdmin)
                    {
                        switch (userChoice)
                        {
                            case 1:  //Dodaj użytkownika
                                break;
                            case 2: //Usuń użytkownika
                                break;
                            case 3:  //Edytuj użytkownika
                                break;
                            case 4: //Wyświetl wszystkich użytkowników
                                break;
                            case 5: //_positions.Add("Cofnij");
                                break;
                            case 6: //_positions.Add("Wyjdź z programu");
                                break;
                        }
                    }
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
                        PrintConfirmation(currentMenu, userChoice);
                        ChangeMenu(menuTickets);
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
            Console.WriteLine("Błąd, wprowadzono błędne dane z poza zakresu, lub podany format jest nieprawidłowy. Spróbuj ponownie\n\n");
        }
        private void PrintConfirmation(MenuCommonLibrary currentMenu, int chosenNr)
        {
            Console.WriteLine($"Wybrałeś opcję nr {chosenNr}:" ); //{currentMenu.Positions[]}
        }

    }
}