using System;
using System.Collections.Generic;
using GymManager.BackEnd;
using GymManager.BackEnd.Menu.MenuLevels;
using GymManager.BackEnd.Menu.MenuLevels.AdminUserMenu;
using GymManager.BackEnd.Users;

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

        private void ChooseMenu(MenuCommonLibrary currentMenu)
        {
           
            currentMenu.Print();
            var userChoice = GetMenuNrFromUser();
            Console.Clear();

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
                            ChooseMenu(menuTickets);
                            break;
                        case 3:
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
                        case 4:
                            PrintConfirmation(currentMenu, userChoice);
                            new SignInLogIn().SignIn(false);
                            ChooseMenu(menuStart);
                            break;
                        case 5:
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
        public void Run(MenuExercises availableExercises)
        {
            Console.WriteLine("Witamy na naszej stronie !\nZapoznaj sie z dostepnymi opcjami :)\n");
            menuExercises = availableExercises;
            ChooseMenu(menuStart);
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
        private Int16 GetMenuNrFromUser()
        {
            Console.WriteLine("\nWpisz nr z menu i wciśnij enter aby przejść dalej\n\n");
            Int16.TryParse(Console.ReadLine(), out Int16 chosenNr);
            return chosenNr;
        }
    }
}