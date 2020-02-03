using System;
using System.Collections.Generic;
using System.Text;

namespace Quizkampen
{
    class ScoreScreenView : View
    {
        public int CurrentScore { get; set; }
        public User User { get; set; }
        public Action MainMenuCallback { get; set; }
        public Action NextQuestionCallback { get; set; }
        public Func<string, Result> InputValidation { get; set; }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine($"Username: {User.UserName}");
            Console.WriteLine($"High Score: {User.HighScore}");
            Console.WriteLine($"Current Score: {CurrentScore}\n\n");
            Console.WriteLine($"Answer another Question?\nY / N");
            MenuOption(ValidateInput(InputValidation));
        }
        void MenuOption(string input)
        {
            switch (input)
            {
                case "y":
                    NextQuestionCallback();
                    break;
                case "n":
                    MainMenuCallback();
                    break;
                default:
                    Console.WriteLine("Enter either Y or N");
                    Display();
                    break;
            }
        }
    }
}
