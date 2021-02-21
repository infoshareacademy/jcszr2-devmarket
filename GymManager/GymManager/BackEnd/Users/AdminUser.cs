using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace GymManager.BackEnd.Users
{
    class AdminUser : User
    {
        private List<User> _users = new JsonManager().GetUsers();
        public void CreateUser()
        {
            Console.WriteLine("Czy użytkownik ma posiadać uprawnienia administratora? Wpisz 'y' lub 'n'");
            var adminRights = Console.ReadLine();
            bool isAdmin = false;

            if (adminRights == "y" || adminRights == "Y")
            {
                isAdmin = true;
            }
            else if (adminRights == "n" || adminRights == "n")
            {
                isAdmin = false;
            }
            else
            {
                Console.WriteLine("Podałeś nieprawidłwoe dane, spróbuj jeszcze raz");
                CreateUser();
            }
            var user = new SignInLogIn().SignIn(isAdmin);
     
        }
        public void PrintAllUsers()
        {
            Console.WriteLine("Zarejestrowani użytkownicy: ");
            foreach (var user in _users.OrderBy(user => user.Email)) Console.WriteLine($"Login: {user.Email}, Hasło: {user.Password}, Admin: {user.IsAdmin} ");
            Console.ReadLine();
        }
        public void DeleteUser()
        {
            Console.WriteLine("Podaj nazwę użytkownika którego chcesz usunąć");
            var userToDelete = Console.ReadLine();
            userToDelete = userToDelete.ToLower();
            
            if (_users.Any(login => login.Email == userToDelete) && userToDelete != User.currentUser.Email)
            {
                new JsonManager().RemoveUser(userToDelete);
                _users = _users.Where(login => login.Email != userToDelete).ToList();
            }
            else
            {
                Console.WriteLine("Nie ma takiego użytkownika lub próbowałeś usunąć aktualnie zalogowanego użytkownika, spróbuj jeszcze raz");
                DeleteUser();
            }
        }
        public void EditUserRights()
        {
            var userToEdit = ChooseUserToEdit();
            Console.WriteLine("Czy użytkownik ma mieć status administratora wpisz y lub n?");
            bool newRights;
            var input = Console.ReadLine();

            if (input == "y" || input == "Y")
            {
                newRights = true;
                new JsonManager().UpdateUserRights(userToEdit, newRights);
            }
            else if (input == "n" || input == "y")
            {
                newRights = false;
                new JsonManager().UpdateUserRights(userToEdit, newRights);
            }
            else
            {
                Console.WriteLine("Podałeś nieprawidłową wartość, spróbuj ponownie");
                EditUserRights();
            }
        }
        public void EditUsername()
        {
            var userToEdit = ChooseUserToEdit();
            Console.WriteLine("Podaj nowy login");
            var newUsername = Console.ReadLine();
            if(new SignInLogIn().IsEmailValid(newUsername))
            {
                new JsonManager().UpdateUserEmail(userToEdit, newUsername);
            }
            else
            {
                Console.WriteLine("Podałeś nieprawidłowy login, spróbuj jeszcze raz");
            }
        }
        public void EditPassword()
        {
            var userToEdit = ChooseUserToEdit();
            var user = _users.First(login => login.Email == userToEdit);
            var newPassword = new SignInLogIn().SetPassword(user);
            new JsonManager().UpdateUserPassword(userToEdit,newPassword);
        }
        private string ChooseUserToEdit()
        {
            Console.WriteLine("Wpisz Login użytkownika którego chcesz edytować");
            var userLogin = Console.ReadLine();
            if (_users.Any(login => login.Email == userLogin))
            {
                return userLogin;
            }
            else
            {
                Console.WriteLine("Błąd, nie znaleziono takiego użytkownika. Spróbuj jeszcze raz");
                return null;
            }
        }
    }
}
