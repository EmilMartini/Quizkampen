using System;

namespace Quizkampen
{
    class MainMenuView : View
    {
        public int NumberOfQuestionsInDatabase { get; set; }
        public Func<string, Result> InputValidation { get; set; }
        public Action DisplayQuestion { get; set; }
        public Action EnterQuestion { get; set; }
        public Action LogOut { get; set; }
        public User ActiveUser { get; set; }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine($"Welcome: {ActiveUser.UserName}");
            Console.WriteLine($"High Score: {ActiveUser.HighScore}\n");
            Console.WriteLine("Select an action");
            Console.Write("1. Play Game \n2. Add Question \n3. Log Out\n4. Exit Game \n\n");
            Console.WriteLine($"Current number of questions in database: {NumberOfQuestionsInDatabase}");
            MenuOption(int.Parse(ValidateInput(InputValidation)));
        }
        private void MenuOption(int input)
        {
            switch (input)
            {
                case 1:
                    DisplayQuestion();
                    break;
                case 2:
                    EnterQuestion();
                    break;
                case 3:
                    LogOut();
                    break;
                case 4:
                    //Exit application, in this case 'nothing' closes the console app.
                    //
                    //Enter your callback to desired exit application method here
                    //
                    break;
                default:
                    Console.Clear();
                    Display();
                    break;
            }
        }
    }
}
