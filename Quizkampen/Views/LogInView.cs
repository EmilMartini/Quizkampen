using System;
using System.Collections.Generic;

namespace Quizkampen
{
    internal class LogInView
    {
        public Action SucessfulLoginCallback { get; set; }
        public List<User> AvailableUsers { get; set; }
        public Func<int,bool> TryLogInCallback { get; set; }
        public Action<User> AddUserCallback { get; set; }
        public Action RefreshView { get; set; } 

        private int input;

        public void Display()
        {
            Console.Clear();
            DisplayUsers();
            Console.WriteLine("Select a user.\nCreate new user [0].");
            CheckInput(out input);
            if (TryLogInCallback(input) && input > 0)
            {
                Console.Clear();
                Console.WriteLine("Loggin in...");
                SucessfulLoginCallback();
            } else if (input == 0)
            {
                CreateUser();
            } else
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
            if(CheckInput(out idInput))
            {
                Console.WriteLine("\nEnter username");
                userName = Console.ReadLine().Trim();
                AddUserCallback(new User 
                {
                    Id = new Guid(),
                    IdentityId = idInput,
                    UserName = userName
                });
                RefreshView();
            }
            
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
        private bool CheckInput(out int output)
        {
            try
            {
                output = int.Parse(Console.ReadKey().KeyChar.ToString());
                if (output < 0)
                {
                    throw new Exception("Given number can't be negative");
                } else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                output = default;
                Console.WriteLine($"Couldn't parse input. \nError message: {ex.Message}\nTry Again...");
                return false;
            }
        }
    }
}