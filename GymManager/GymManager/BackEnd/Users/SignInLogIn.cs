using System;
using System.Linq;
using System.Security;

namespace GymManager.BackEnd.Users
{
    public class SignInLogIn
    {
        public void LogIn()
        {

        }

        public void SignIn()
        {
            var user = new User();
            SetEmail(user);
            SetPassword(user);
            new JsonReader().addUserToJsonUsersFile(user);
            PrintOperationSuccess();
        }
        private void SetEmail(User user)
        {
            Console.WriteLine("Podaj swój email:\n");
            var enteredEmail = Console.ReadLine();
            var normalizedEmail = enteredEmail.ToLower();

            if (IsEmailValid(normalizedEmail))
            {
                Console.Clear();
                user.Email= normalizedEmail;
            }
            Console.WriteLine("Wprowadzony email jest nieprawidłowy lub jest już zarejestrowany, spróbój ponownie");
            Console.Read();
            Console.Clear();
            SetEmail(user);
        }
        private void SetPassword(User user)
        {
            Console.WriteLine("Podaj hasło." +
                              "\nKryteria\n" +
                              "\n*Musi składać się z conajmniej 6 cyfr i nie więcej niż20" +
                              "\n*Conajmniej 1 wielka litera" +
                              "\n*Conajmniej 1 cyfra" +
                              "\n*Zabronione znaki: przecinek,spacja,<,>,',;, \n\n");

            SecureString passwordToSecure1 = WriteTextInHideMode();
            string _password1 = new System.Net.NetworkCredential(string.Empty, passwordToSecure1).Password;

            Console.Clear();
            Console.WriteLine("Powtórz wprowadzone hasło");
            SecureString passwordToSecure2 = WriteTextInHideMode();
            string _password2 = new System.Net.NetworkCredential(string.Empty, passwordToSecure1).Password;

            if (IsPasswordValid(_password1,_password2))
            {
                user.Password= _password1;
            }
            Console.WriteLine("Wprowadzone hasło nie spełnia kryteriów lub nie wprowadzono 2 takich samych haseł, wciśnij enter i spróbój ponownie");
            Console.Read();
            Console.Clear();
            SetPassword(user);
        }
        private bool IsPasswordValid(string password1,string password2)
        {
            //var allowedChars = new Regex("^[a-zA-Z0-9 ]+$");
            var prohibitedChars = " <>',; ".ToCharArray();
            if (password1 == password2 
                && password1.Length >= 6
                && password1.Length <= 20
                && password1.Any(Char.IsUpper)
                && password1.Any(char.IsDigit)
                && !password1.Any(prohibitedCar => prohibitedChars.Contains(prohibitedCar)))
            {
                return true;
            }
            return false;
        }
        private bool IsEmailValid(string userEmail)
        {
            var usersList = new JsonReader().readJsonUsersFile();
            bool isAlreadyRegistered = usersList.Any(user => user.Email == userEmail);

            if (userEmail != null && !isAlreadyRegistered)
            {
                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(userEmail);
                    return mailAddress.Address == userEmail;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        private SecureString WriteTextInHideMode()
        {
            SecureString password = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    password.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.RemoveAt(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            {
                return password;
            }
        }
        private void PrintOperationSuccess()
        {
            Console.Clear();
            Console.WriteLine("Operacja wykonana pomyślnie, wciśnij dowolny klawisz aby przejść do menu");
            Console.ReadLine();
            Console.Clear();
        }
        
    }
}