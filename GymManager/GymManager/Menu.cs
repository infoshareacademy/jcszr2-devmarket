using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager
{
    public class Menu
    {
        public static void PrintWelcomeMenu()
        {
            PrintMenu(MenuRepository.StartMenu);
            GetOptionNr(MenuRepository.StartMenu);
        }


        private static void GetOptionNr(Dictionary<int,string> currentMenu)
        {
            Int16 chosenNr;

            if(Int16.TryParse(Console.ReadLine(), out chosenNr))
            {
                SwitchMenu(currentMenu, chosenNr);
            }
            else
            {
                PrintErrorInputData();
                PrintMenu(currentMenu);
            }
        }

        private static void SwitchMenu(Dictionary<int, string> currentMenu, int menuNr)
        {
            if(currentMenu==MenuRepository.StartMenu)
            {                
                switch (menuNr)
                {
                    case 1: 
                        PrintMenu(MenuRepository.Exercises);
                        GetOptionNr(MenuRepository.Exercises);
                        break;
                    case 2: 
                        PrintMenu(MenuRepository.Tickets);
                        GetOptionNr(MenuRepository.Tickets);
                        break;
                    case 3: 
                        // To be implemented (register)
                        Console.WriteLine("Wybrano 3");
                        break;
                    case 4: 
                        // To be implemented (login)
                        Console.WriteLine("Wybrano 4");
                        break;
                    case 5:  
                        Environment.Exit(0);
                        break;
                    default:
                        PrintErrorInputData();
                        PrintMenu(currentMenu);
                        break;
                }
            }
            else if(currentMenu==MenuRepository.Exercises)
            {
            }
            else if(currentMenu==MenuRepository.Tickets)
            {
            }
        }

        private static void PrintMenu(Dictionary<int,string> menuToBeDisplayed)
        {
            Console.Clear();
            if(menuToBeDisplayed==MenuRepository.StartMenu)
            {
                Console.WriteLine("Witaj na naszej stronie! :)\n");
            }

            Console.WriteLine("\nWybierz numer pozycji");
            foreach (KeyValuePair<int, string> element in menuToBeDisplayed)
            {
                Console.WriteLine($"{element.Key}. {element.Value}");
            }
            Console.WriteLine("");

            
        }

        private static void PrintErrorInputData()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Błąd, wprowadzono błędne dane z poza zakresu, lub podany format jest nieprawidłowy. Spróbuj ponownie\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }

}