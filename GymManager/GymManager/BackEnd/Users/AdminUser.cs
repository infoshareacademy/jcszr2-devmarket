using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace GymManager.BackEnd.Users
{
    class AdminUser : User
    {
        private List<User> _users = new JsonReader().readUsers();
        public void CreateUser()
        {
            var user = new SignInLogIn().SignIn();
            Console.WriteLine("Czy użytkownik ma posiadać uprawnienia administratora? Wpisz 'y' lub 'n'");
            var adminRights = Console.ReadKey().KeyChar;

            if (adminRights == 'y' || adminRights == 'Y')
            {
                user.IsAdmin = true;
                Console.WriteLine($"Pomyślnie dodano użytkownika {user.Email}");
            }
            else if (adminRights == 'n' || adminRights == 'n')
            {
                user.IsAdmin = false;
                Console.WriteLine($"Pomyślnie dodano użytkownika {user.Email}");
            }
            else
            {
                Console.WriteLine("Podałeś nieprawidłwoe dane, spróbuj jeszcze raz");
                CreateUser();
            }
        }
        public void ReadAllUsers()
        {
            Console.WriteLine("Zarejestrowani użytkownicy: ");
            foreach (var user in _users.OrderBy(user => user.Email)) Console.WriteLine($"Login: {user.Email}, Hasło: {user.Password}, Admin: {user.IsAdmin} ");
            Console.ReadLine();
        }
        public void UpdateUser()
        {
            Console.WriteLine("Wpisz Login użytkownika którego chcesz edytować");
            var userLogin = Console.ReadLine();
            if(_users.Any(login=>login.Email == userLogin))
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Błąd, nie znaleziono takiego użytkownika. Spróbuj jeszcze raz");
            }
        }
        public void DeleteUser(string username)
        {

        }
        public void EditPassword(string username)
        {

        }

        public void EditUsername(string username)
        {

        }


    }
}
