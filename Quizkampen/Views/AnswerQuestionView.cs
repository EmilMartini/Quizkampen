using System;

namespace Quizkampen
{
    internal class AnswerQuestionView : View
    {
        public Question GeneratedQuestion { get; set; }
        public Func<string, Result> ParseInputValidation { get; set; }
        public Action ScoreScreenCallback { get; set; }
        public Action IncreaseScoreCallback { get; set; }
        public Action MainMenuCallback { get; set; }

        private int correctAnswerIndex;
        private int index = 1;

        public void Display()
        {
            Console.Clear();
            if(GeneratedQuestion == null)
            {
                Console.WriteLine("No questions in database.");
                Console.WriteLine("Enter one before playing.");
                WaitForKeyPress();
                MainMenuCallback();
            }

            DisplayQuestion();
            Console.WriteLine("\nAnswer by entering [Answer Id].");
            CheckIfCorrect(int.Parse(ValidateInput(ParseInputValidation)));
        }
        private void DisplayQuestion()
        {
            Console.WriteLine($"Question: {GeneratedQuestion.Title}");
            foreach (var answer in GeneratedQuestion.Answers)
            {
                Console.WriteLine($"[{index}]: \t{answer.Title}");
                index++;
                if (answer.isCorrect)
                {
                    correctAnswerIndex = index - 1;
                }
            }
        }
        private void CheckIfCorrect(int userInput)
        {
            Console.WriteLine();
            if(userInput == correctAnswerIndex)
            {
                Console.WriteLine($"Congratulations! You answered correctly.");
                IncreaseScoreCallback();
            } else
            {
                Console.WriteLine("Sorry, that's wrong! Better luck next time...");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            ScoreScreenCallback();
        }
    }
}