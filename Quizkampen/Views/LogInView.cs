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
        public Func<string, Result> ValidateInputParse { get; set; }

        public void Display()
        {
            Console.Clear();
            DisplayUsers();
            Console.WriteLine("Select a user.\nCreate new user [0].");
            int input = int.Parse(ValidateInput(ValidateInputParse));
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
            Console.WriteLine("Enter identity ID");
            idInput = int.Parse(ValidateInput(ValidateInputParse));
            Console.WriteLine("\nEnter username");
            userName = Console.ReadLine().Trim();
            AddUserCallback(new User
            {
                Id = new Guid(),
                IdentityId = idInput,
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
                    Console.WriteLine($"Id: {user.IdentityId}\tUsername: {user.UserName}");
                }
            }
            Console.WriteLine();
        }
    }
}