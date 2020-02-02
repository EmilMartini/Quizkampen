﻿using System;

namespace Quizkampen
{
    class MainMenuView
    {
        public int NumberOfQuestionsInDatabase { get; set; }
        public Action DisplayQuestion { get; set; }
        public Action EnterQuestion { get; set; }
        public Action ExitGame { get; set; }


        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Select an action");
            Console.Write("1. Play Game \n2. Add Question \n3. Exit Game \n\n");
            Console.WriteLine($"Current number of questions in database: {NumberOfQuestionsInDatabase}");
            var result = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            try
            {
                var parsedResult = int.Parse(result);
                MenuOption(parsedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"You entered an incorrect input.\nError message: {ex.Message}\nTry again.");
                Console.ReadKey();
                Console.Clear();
                Display();
            }
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