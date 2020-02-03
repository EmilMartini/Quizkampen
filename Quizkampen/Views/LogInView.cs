using System;
using System.Collections.Generic;

namespace Quizkampen
{
    internal class LogInView : View
    {
        public Action SucessfulLoginCallback { get; set; }
        public List<User> AvailableUsers { get; set; }
        public Func<int,bool> TryLogInCallback { get; set; }
        public Action<User> AddUserCallback { get; set; }
        public Action RefreshView { get; set; } 
        public Func<string, Result> ParseInputValidation { get; set; }

        public void Display()
        {
            Console.Clear();
            DisplayUsers();
            Console.WriteLine("Select a user by entering its ID.\nCreate new user [0].");
            int input = int.Parse(ValidateInput(ParseInputValidation));
            TryLogIn(input);
        }
        private void TryLogIn(int input)
        {
            if (TryLogInCallback(input) && input > 0)
            {
                Console.Clear();
                Console.WriteLine("Loggin in...");
                SucessfulLoginCallback();
            }
            else if (input == 0)
            {
                CreateUser();
                RefreshView();
            }
            else
            {
                Console.WriteLine("Error logging in.\nTry Again.");
                Display();
            }
        }
        private void CreateUser()
        {
            int idInput = 0;
            string userName;
            Console.Clear();
            Console.WriteLine("Choose LogIn ID");
            idInput = int.Parse(ValidateInput(ParseInputValidation));
            Console.WriteLine("\nChoose username");
            userName = Console.ReadLine().Trim();
            AddUserCallback(new User
            {
                Id = new Guid(),
                LogInId = idInput,
                UserName = userName
            });
        }
        private void DisplayUsers()
        {
            if(AvailableUsers == null)
            {
                Console.WriteLine("No available users in database.\nCreate one by pressing [0].");
            } else
            {
                Console.WriteLine("Available Users: ");
                foreach (var user in AvailableUsers)
                {
                    Console.WriteLine($"Id: {user.LogInId}\tUsername: {user.UserName}");
                }
            }
            Console.WriteLine();
        }
    }
}